namespace Commons.Logging;

internal class NoLogContext : ILogContext
{
    public static readonly NoLogContext Instance = new NoLogContext();

    public void Dispose() { }
}