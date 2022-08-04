using System;
using System.Collections.Generic;
using System.Net;
using Commons.Logging;

namespace MoneyManager.Commons.Network;

public class FaultTolerantHttpClientConfiguration
{
    public string Uris { get; set; } = null!;

    public char UriDelimiter { get; set; } = ' ';

    public string? Login { get; set; }

    public string? Password { get; set; }

    public TimeSpan RetryInterval { get; set; } = TimeSpan.FromSeconds(30);
}

public abstract class FaultTolerantHttpClient
{
    private static readonly ILogger Logger = LoggerFactory.Create<FaultTolerantHttpClient>();

    private readonly FaultTolerantHttpClientConfiguration _configuration;
    private readonly IHttpClient _httpClient;

    private readonly IList<HttpEndPointContext> _contexts = new List<HttpEndPointContext>();

    protected FaultTolerantHttpClient(FaultTolerantHttpClientConfiguration configuration,
                                      IHttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient    = httpClient;

        var uris = _configuration.Uris.Split(_configuration.UriDelimiter);

        foreach (var uri in uris)
        {
            _contexts.Add(new HttpEndPointContext(_configuration.RetryInterval)
            {
                Uri = uri.Trim()
            });
        }
    }

    public string Get(string uri, HttpRequestParams requestParams)
    {
        NetworkCredential? networkCredential = null;
        if (_configuration.Login != null && _configuration.Password != null)
            networkCredential = new NetworkCredential(_configuration.Login, _configuration.Password);


        foreach (var context in _contexts)
        {
            var fullUri = ConcatUris(context.Uri, uri);

            try
            {
                return context.CircuitBreaker.Execute(() => _httpClient.Get(fullUri, requestParams, networkCredential));
            }
            catch (CircuitBreakerOpenException)
            {
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Cannot GET {Uri}", fullUri);
            }
        }

        throw new NoAvailableHttpEndpointsFound();
    }

    public HttpResponse HttpGet(string uri, HttpRequestParams requestParams)
    {
        NetworkCredential? networkCredential = null;
        if (_configuration.Login != null && _configuration.Password != null)
            networkCredential = new NetworkCredential(_configuration.Login, _configuration.Password);

        foreach (var context in _contexts)
        {
            var fullUri = ConcatUris(context.Uri, uri);

            try
            {
                return context.CircuitBreaker.Execute(() => _httpClient.HttpGet(fullUri, requestParams, networkCredential));
            }
            catch (CircuitBreakerOpenException)
            {
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Cannot GET {Uri}", fullUri);
            }
        }

        throw new NoAvailableHttpEndpointsFound();
    }

    protected string Post(string uri, HttpPostRequestParams requestParams)
    {
        NetworkCredential? networkCredential = null;

        if (_configuration.Login != null && _configuration.Password != null)
            networkCredential = new NetworkCredential(_configuration.Login, _configuration.Password);

        foreach (var context in _contexts)
        {
            var fullUri = ConcatUris(context.Uri, uri);

            try
            {
                return context.CircuitBreaker.Execute(() => _httpClient.Post(fullUri, requestParams, networkCredential));
            }
            catch (CircuitBreakerOpenException)
            {
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Cannot POST {Uri}", fullUri);
            }
        }

        throw new NoAvailableHttpEndpointsFound();
    }

    public HttpResponse HttpPost(string uri, HttpPostRequestParams requestParams)
    {
        NetworkCredential? networkCredential = null;

        if (_configuration.Login != null && _configuration.Password != null)
            networkCredential = new NetworkCredential(_configuration.Login, _configuration.Password);

        foreach (var context in _contexts)
        {
            var fullUri = ConcatUris(context.Uri, uri);

            try
            {
                return context.CircuitBreaker.Execute(() => _httpClient.HttpPost(fullUri, requestParams, networkCredential));
            }
            catch (CircuitBreakerOpenException)
            {
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Cannot POST {Uri}", fullUri);
            }
        }

        throw new NoAvailableHttpEndpointsFound();
    }

    private static Uri ConcatUris(string baseUri, string uri)
    {
        if (string.IsNullOrEmpty(uri))
            return new Uri(baseUri);

        if (!baseUri.EndsWith("/"))
            baseUri = $"{baseUri}/";

        return new Uri(new Uri(baseUri), uri);
    }
}