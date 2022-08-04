using System;

namespace Commons.Logging;

public interface ILoggerFactory
{
    ILogger Logger { get; }

    ILogger Create(Type context);

    void CloseAndFlush();
}