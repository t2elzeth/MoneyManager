using Serilog.Events;
using System;

namespace Commons.Logging.Serilog;

public class SerilogLogger : ILogger
{
    private readonly global::Serilog.ILogger _log;

    public SerilogLogger(global::Serilog.ILogger logger)
    {
        _log = logger ?? throw new ArgumentNullException(nameof(logger));
    }
        
    public bool IsDebugEnabled => _log.IsEnabled(LogEventLevel.Debug);

    public bool IsInfoEnabled => _log.IsEnabled(LogEventLevel.Information);

    public bool IsWarnEnabled => _log.IsEnabled(LogEventLevel.Warning);

    public bool IsErrorEnabled => _log.IsEnabled(LogEventLevel.Error);

    public bool IsEnabled(LogLevel level)
    {
        return _log.IsEnabled((LogEventLevel)level);
    }

    public void Debug(string messageTemplate)
    {
        _log.Debug(messageTemplate);
    }

    public void Debug<T>(string messageTemplate, T propertyValue)
    {
        _log.Debug(messageTemplate, propertyValue);
    }

    public void Debug<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        _log.Debug(messageTemplate, propertyValue0, propertyValue1);
    }

    public void Debug<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        _log.Debug(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    public void Debug(string messageTemplate, params object[] propertyValues)
    {
        _log.Debug(messageTemplate, propertyValues);
    }

    public void Debug(Exception exception, string messageTemplate)
    {
        _log.Debug(exception, messageTemplate);
    }

    public void Debug<T>(Exception exception, string messageTemplate, T propertyValue)
    {
        _log.Debug(exception, messageTemplate, propertyValue);
    }

    public void Debug<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        _log.Debug(exception, messageTemplate, propertyValue0, propertyValue1);
    }

    public void Debug<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1,
                                  T2 propertyValue2)
    {
        _log.Debug(exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    public void Debug(Exception exception, string messageTemplate, params object[] propertyValues)
    {
        _log.Debug(exception, messageTemplate, propertyValues);
    }

    public void Info(string messageTemplate)
    {
        _log.Information(messageTemplate);
    }

    public void Info<T>(string messageTemplate, T propertyValue)
    {
        _log.Information(messageTemplate, propertyValue);
    }

    public void Info<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        _log.Information(messageTemplate, propertyValue0, propertyValue1);
    }

    public void Info<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        _log.Information(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    public void Info(string messageTemplate, params object[] propertyValues)
    {
        _log.Information(messageTemplate, propertyValues);
    }

    public void Info(Exception exception, string messageTemplate)
    {
        _log.Information(exception, messageTemplate);
    }

    public void Info<T>(Exception exception, string messageTemplate, T propertyValue)
    {
        _log.Information(exception, messageTemplate, propertyValue);
    }

    public void Info<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        _log.Information(exception, messageTemplate, propertyValue0, propertyValue1);
    }

    public void Info<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1,
                                 T2 propertyValue2)
    {
        _log.Information(exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    public void Info(Exception exception, string messageTemplate, params object[] propertyValues)
    {
        _log.Information(exception, messageTemplate, propertyValues);
    }

    public void Warn(string messageTemplate)
    {
        _log.Warning(messageTemplate);
    }

    public void Warn<T>(string messageTemplate, T propertyValue)
    {
        _log.Warning(messageTemplate, propertyValue);
    }

    public void Warn<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        _log.Warning(messageTemplate, propertyValue0, propertyValue1);
    }

    public void Warn<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        _log.Warning(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    public void Warn(string messageTemplate, params object[] propertyValues)
    {
        _log.Warning(messageTemplate, propertyValues);
    }

    public void Warn(Exception exception, string messageTemplate)
    {
        _log.Warning(exception, messageTemplate);
    }

    public void Warn<T>(Exception exception, string messageTemplate, T propertyValue)
    {
        _log.Warning(exception, messageTemplate, propertyValue);
    }

    public void Warn<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        _log.Warning(exception, messageTemplate, propertyValue0, propertyValue1);
    }

    public void Warn<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1,
                                 T2 propertyValue2)
    {
        _log.Warning(exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    public void Warn(Exception exception, string messageTemplate, params object[] propertyValues)
    {
        _log.Warning(exception, messageTemplate, propertyValues);
    }

    public void Error(string messageTemplate)
    {
        _log.Error(messageTemplate);
    }

    public void Error<T>(string messageTemplate, T propertyValue)
    {
        _log.Error(messageTemplate, propertyValue);
    }

    public void Error<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        _log.Error(messageTemplate, propertyValue0, propertyValue1);
    }

    public void Error<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        _log.Error(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    public void Error(string messageTemplate, params object[] propertyValues)
    {
        _log.Error(messageTemplate, propertyValues);
    }

    public void Error(Exception exception, string messageTemplate)
    {
        _log.Error(exception, messageTemplate);
    }

    public void Error<T>(Exception exception, string messageTemplate, T propertyValue)
    {
        _log.Error(exception, messageTemplate, propertyValue);
    }

    public void Error<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        _log.Error(exception, messageTemplate, propertyValue0, propertyValue1);
    }

    public void Error<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1,
                                  T2 propertyValue2)
    {
        _log.Error(exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    public void Error(Exception exception, string messageTemplate, params object[] propertyValues)
    {
        _log.Error(exception, messageTemplate, propertyValues);
    }

    public void Fatal(string messageTemplate)
    {
        _log.Fatal(messageTemplate);
    }

    public void Fatal<T>(string messageTemplate, T propertyValue)
    {
        _log.Fatal(messageTemplate, propertyValue);
    }

    public void Fatal<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        _log.Fatal(messageTemplate, propertyValue0, propertyValue1);
    }

    public void Fatal<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        _log.Fatal(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    public void Fatal(string messageTemplate, params object[] propertyValues)
    {
        _log.Fatal(messageTemplate, propertyValues);
    }

    public void Fatal(Exception exception, string messageTemplate)
    {
        _log.Fatal(exception, messageTemplate);
    }

    public void Fatal<T>(Exception exception, string messageTemplate, T propertyValue)
    {
        _log.Fatal(exception, messageTemplate, propertyValue);
    }

    public void Fatal<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {
        _log.Fatal(exception, messageTemplate, propertyValue0, propertyValue1);
    }

    public void Fatal<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1,
                                  T2 propertyValue2)
    {
        _log.Fatal(exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    public void Fatal(Exception exception, string messageTemplate, params object[] propertyValues)
    {
        _log.Fatal(exception, messageTemplate, propertyValues);
    }

    public ILogContext PushContext(string name, object context)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        if (context == null)
            throw new ArgumentNullException(nameof(context));

        return new SerilogLogContext(name, context);
    }
}