using System;

namespace Commons.Logging;

public class NoLoggerFactory : ILoggerFactory
{
    public ILogger Logger => NoLogger.Instance;

    public ILogger Create(Type context)
    {
        return NoLogger.Instance;
    }

    public void CloseAndFlush()
    {
            
    }
}