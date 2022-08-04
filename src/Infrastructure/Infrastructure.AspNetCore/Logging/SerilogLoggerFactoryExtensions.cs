using Serilog;
using Serilog.Exceptions;

namespace Infrastructure.AspNetCore.Logging;

public static class SerilogLoggerFactoryExtensions
{
    public static LoggerConfiguration WithDefaults(this LoggerConfiguration cfg) =>
        cfg.Enrich.WithExceptionDetails()
           .Enrich.WithMachineName();
}