using Serilog.Context;
using System;

namespace Commons.Logging.Serilog;

internal sealed class SerilogLogContext : ILogContext
{
    private readonly IDisposable _context;

    public SerilogLogContext(string name, object value)
    {
        _context = LogContext.PushProperty(name, value, true);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}