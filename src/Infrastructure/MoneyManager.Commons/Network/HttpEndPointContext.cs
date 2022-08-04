using System;

namespace MoneyManager.Commons.Network;

internal class HttpEndPointContext
{
    public HttpEndPointContext(TimeSpan retryInterval)
    {
        CircuitBreaker = new CircuitBreaker(retryInterval);
    }

    public CircuitBreaker CircuitBreaker { get; }

    public string Uri { get; set; } = null!;
}