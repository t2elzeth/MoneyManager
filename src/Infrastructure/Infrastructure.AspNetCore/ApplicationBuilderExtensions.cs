using Infrastructure.AspNetCore.Logging;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure.AspNetCore;

public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Requests logging and metrics endpoint
    /// </summary>
    /// <param name="app">The <see cref="T:Microsoft.AspNetCore.Builder.IApplicationBuilder" />.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IApplicationBuilder UseObservability(this IApplicationBuilder app)
    {
        app.UseSerilogRequestLoggingExtended();

        return app;
    }
}