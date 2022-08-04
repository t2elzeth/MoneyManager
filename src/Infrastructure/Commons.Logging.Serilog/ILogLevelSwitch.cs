using Serilog.Core;

namespace Commons.Logging.Serilog;

public interface ILogLevelSwitch
{
    LoggingLevelSwitch LoggingLevelSwitch { get; }
}