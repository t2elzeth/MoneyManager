using System;

namespace Commons.Logging;

public static class LoggerFactory
{
    private static ILoggerFactory? _instance;

    public static ILoggerFactory Instance
    {
        get => _instance ??= new NoLoggerFactory();
        set => _instance = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static ILogger Create(Type type)
    {
        if (type == null)
            throw new ArgumentNullException(nameof(type));

        return Instance.Create(type);
    }

    public static ILogger Create<T>()
    {
        return Create(typeof(T));
    }
}