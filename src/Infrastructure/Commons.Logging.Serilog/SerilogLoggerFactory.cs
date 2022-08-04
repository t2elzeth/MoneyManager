using Serilog;
using System;

namespace Commons.Logging.Serilog;

public sealed class SerilogLoggerFactory : ILoggerFactory
{
    private readonly global::Serilog.ILogger _serilogSerilogLogger;

    public ILogger Logger { get; }

    public SerilogLoggerFactory(LoggerConfiguration configuration)
    {
        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        _serilogSerilogLogger = configuration
                                .Enrich.FromLogContext()
                                .CreateLogger();

        Log.Logger = _serilogSerilogLogger;

        Logger = new SerilogLogger(Log.Logger);
    }

    public SerilogLoggerFactory(global::Serilog.ILogger serilogLogger)
    {
        _serilogSerilogLogger = serilogLogger ?? throw new ArgumentNullException(nameof(serilogLogger));

        Logger = new SerilogLogger(Log.Logger);
    }

    public ILogger Create(Type context)
    {
        return new SerilogLogger(_serilogSerilogLogger.ForContext(context));
    }

    public void CloseAndFlush()
    {
        Log.CloseAndFlush();
    }
}