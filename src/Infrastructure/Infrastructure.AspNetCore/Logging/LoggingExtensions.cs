using Microsoft.AspNetCore.Builder;
using Serilog;

namespace Infrastructure.AspNetCore.Logging;

public static class LoggingExtensions
{
    public static IApplicationBuilder UseSerilogRequestLoggingExtended(this IApplicationBuilder app)
    {
        return app.UseSerilogRequestLogging(opts =>
        {
            opts.EnrichDiagnosticContext = LogHelper.EnrichFromRequest;
            opts.GetLevel                = LogHelper.ExcludeHealthChecks;
        });
    }
}