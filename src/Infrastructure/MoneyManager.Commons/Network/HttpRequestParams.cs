using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Commons.Network;

public abstract class HttpRequestParams
{
    public Encoding Encoding { get; } = Encoding.UTF8;

    public abstract IDictionary<string, string> QueryParameters { get; }
}