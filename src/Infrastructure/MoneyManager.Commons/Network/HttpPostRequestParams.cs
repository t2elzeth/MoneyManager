using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MoneyManager.Commons.Network;

public class HttpPostRequestParams
{
    public WebHeaderCollection Headers { get; set; } = new()
    {
        [HttpRequestHeader.ContentType] = "application/json"
    };

    public Encoding Encoding { get; set; } = Encoding.UTF8;

    public string Data { get; set; } = null!;

    public virtual IDictionary<string, string> QueryParameters { get; } = new Dictionary<string, string>();
}