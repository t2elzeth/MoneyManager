using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autofac;
using Infrastructure.AspNetCore;
using Infrastructure.AspNetCore.Extensions;
using Infrastructure.AspNetCore.Validation;
using Infrastructure.DataTypes.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using MoneyManager.Application.Nh;

WebApplicationBoostrap.Create(args)
                      .ContainerBuilder((_, containerBuilder) =>
                      {
                          containerBuilder.RegisterAssemblyModules(Assembly.Load("ElPay.Application.Customer"));
                          containerBuilder.RegisterAssemblyModules(Assembly.Load("ElPay.Customer.API"));
                      })
                      .Build(builder =>
                      {
                          var services      = builder.Services;
                          var configuration = builder.Configuration;

                          services.AddMvcCore()
                                  .UseCustomModelValidation()
                                  .AddControllersAsServices();

                          services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                                  .AddCookie(options =>
                                  {
                                      options.Cookie.Name       = "wallet";
                                      options.ExpireTimeSpan    = TimeSpan.FromMinutes(1);
                                      options.SlidingExpiration = true;

                                      options.Events = new CookieAuthenticationEvents
                                      {
                                          OnRedirectToLogin = redirectContext =>
                                          {
                                              redirectContext.HttpContext.Response.StatusCode = 401;
                                              return Task.CompletedTask;
                                          }
                                      };
                                  });

                          services.AddSession(options =>
                          {
                              options.Cookie.Name = "wallet-session";
                              options.IdleTimeout = TimeSpan.FromMinutes(1);
                          });

                          services.AddSingleton(NhSessionFactory.Instance);

                          services.AddApiVersioning();
                      })
                      .ConfigureCors(c =>
                      {
                          c.AddDefaultPolicy(p => p.AllowAnyOrigin()
                                                   .AllowAnyMethod()
                                                   .AllowAnyHeader());
                      })
                      .ConfigureFluentValidation(config =>
                      {
                          config.ValidatorOptions.PropertyNameResolver = CamelCasePropertyNameResolver.ResolvePropertyName;
                          config.DisableDataAnnotationsValidation      = true;
                          config.ImplicitlyValidateChildProperties     = true;
                          config.RegisterValidatorsFromAssembly(Assembly.Load("MoneyManager.Application"));
                      })
                      .ConfigureSerializer(options =>
                      {
                          options.JsonSerializerOptions.ConfigureSystem();
                          options.JsonSerializerOptions.AddConverter(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                      })
                      .Configure(app =>
                      {
                          app.UseSession();
                          app.UseRouting();
                          app.UseCors();
                          app.UseAuthentication();
                          app.UseAuthorization();

                          app.MapControllers();
                      })
                      .Start("MoneyManager.API");