using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Commons.Logging;
using Commons.Logging.Serilog;
using Dapper;
using FluentValidation.AspNetCore;
using Infrastructure.AspNetCore.Nh;
using Infrastructure.AspNetCore.Timeout;
using Infrastructure.DataTypes;
using Infrastructure.DataTypes.Serialization;
using Infrastructure.Nh.Postgres;
using Infrastructure.Nh.Postgres.Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.WindowsServices;
using NHibernate;
using Serilog;
using Serilog.Exceptions;
using ILoggerFactory = Commons.Logging.ILoggerFactory;

namespace Infrastructure.AspNetCore;

public class WebApplicationBoostrap
{
    private readonly WebApplicationBuilder _builder;
    private Action<IConfiguration, ContainerBuilder>? _containerBuilder;
    private Action<WebApplicationBuilder>? _build;
    private Action<IMvcBuilder>? _buildMvc;
    private Action<WebApplication>? _configure;
    private Action<JsonOptions>? _configureSerializer;
    private Action<CorsOptions>? _configureCors;
    private Action<FluentValidationMvcConfiguration>? _configureFluentValidation;

    private WebApplicationBoostrap(WebApplicationBuilder builder)
    {
        _builder = builder;
    }

    public static WebApplicationBoostrap Create(string[] args)
    {
        var webApplicationOptions = new WebApplicationOptions
        {
            Args            = args,
            ContentRootPath = WindowsServiceHelpers.IsWindowsService() ? AppContext.BaseDirectory : default
        };

        var builder = WebApplication.CreateBuilder(webApplicationOptions);

        builder.Configuration.AddJsonFile("appsettings/appsettings.Kubernetes.json", optional: true);

        return new WebApplicationBoostrap(builder);
    }

    public WebApplicationBoostrap ContainerBuilder(Action<IConfiguration, ContainerBuilder> containerBuilder)
    {
        _containerBuilder = containerBuilder;
        return this;
    }

    public WebApplicationBoostrap Build(Action<WebApplicationBuilder> build)
    {
        _build = build;
        return this;
    }

    public WebApplicationBoostrap BuildMvc(Action<IMvcBuilder> buildMvc)
    {
        _buildMvc = buildMvc;
        return this;
    }

    public WebApplicationBoostrap Configure(Action<WebApplication> configure)
    {
        _configure = configure;
        return this;
    }

    public WebApplicationBoostrap ConfigureSerializer(Action<JsonOptions> configureSerializer)
    {
        _configureSerializer = configureSerializer;
        return this;
    }

    public WebApplicationBoostrap ConfigureCors(Action<CorsOptions> configureCors)
    {
        _configureCors = configureCors;
        return this;
    }

    public WebApplicationBoostrap ConfigureFluentValidation(Action<FluentValidationMvcConfiguration> configureFluentValidation)
    {
        _configureFluentValidation = configureFluentValidation;
        return this;
    }

    public void Start(string applicationName)
    {
        var configuration = _builder.Configuration;
        LoggerFactory.Instance = CreateLoggerFactory(configuration);

        try
        {
            LoggerFactory.Instance.Logger.Info("{ApplicationName} is starting", applicationName);

            DefaultTypeMap.MatchNamesWithUnderscores = true;
            SqlMapper.AddTypeHandler(typeof(DateTime), new LegacyUtcDateTimeHandler());
            SqlMapper.AddTypeHandler(typeof(UtcDateTime), new UtcDateTimeHandler());
            SqlMapper.AddTypeHandler(typeof(KgDateTime), new KgDateTimeHandler());
            SqlMapper.AddTypeHandler(typeof(Date), new DateHandler());

            _builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuilder => //
            {
                _containerBuilder?.Invoke(configuration, containerBuilder);
            }));

            _builder.Host
                    .UseWindowsService()
                    .UseSerilog();

            ConnectionStringsManager.ReadFromConfiguration(configuration);

            _build?.Invoke(_builder);

            if (_configureCors is not null)
            {
                _builder.Services.AddCors(c => //
                {
                    _configureCors.Invoke(c);
                });
            }

            if (_configureFluentValidation is not null)
            {
                _builder.Services.AddFluentValidation(config => //
                {
                    _configureFluentValidation.Invoke(config);
                });
            }

            var mvcBuilder = _builder.Services
                                     .AddControllersWithViews(options => //
                                     {
                                         options.Filters.Add<NhSessionAttributeActionFilter>();
                                     })
                                     .AddJsonOptions(options => //
                                     {
                                         options.JsonSerializerOptions.ConfigureSystem();

                                         _configureSerializer?.Invoke(options);
                                     });

            _builder.Services.Configure<MvcOptions>(options =>
            {
                options.ModelBinderProviders.RemoveType<CancellationTokenModelBinderProvider>();
                options.ModelBinderProviders.Insert(0, new TimeoutCancellationTokenModelBinderProvider());
            });

            _builder.Services.Configure<TimeoutOptions>(_ => { });

            _buildMvc?.Invoke(mvcBuilder);

            _builder.Services.AddEndpointsApiExplorer();
            _builder.Services.AddSwaggerGen();

            var app = _builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            _configure?.Invoke(app);

            app.Run();

            LoggerFactory.Instance.CloseAndFlush();
        }
        catch (Exception ex)
        {
            LoggerFactory.Instance.Logger.Fatal(ex, "Host terminated unexpectedly");
            LoggerFactory.Instance.CloseAndFlush();
            Environment.Exit(-1);
        }
    }

    private static ILoggerFactory CreateLoggerFactory(IConfiguration configuration)
    {
        var loggerConfiguration = new LoggerConfiguration()
                                  .Enrich.WithExceptionDetails()
                                  .Enrich.WithMachineName()
                                  .ReadFrom.Configuration(configuration);

        return new SerilogLoggerFactory(loggerConfiguration);
    }
}