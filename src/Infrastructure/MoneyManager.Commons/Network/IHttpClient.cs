using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Commons.Logging;

namespace MoneyManager.Commons.Network;

public class HttpResponse
{
    public bool IsFailure { get; }

    public string Content { get; }

    public HttpResponse(bool isFailure, string content)
    {
        IsFailure = isFailure;
        Content   = content;
    }
}

public interface IHttpClient
{
    string Get(Uri uri, HttpRequestParams request, ICredentials? credentials = null);

    HttpResponse HttpGet(Uri uri, HttpRequestParams request, ICredentials? credentials = null);

    string Post(Uri uri, HttpPostRequestParams request, ICredentials? credentials = null);

    HttpResponse HttpPost(Uri uri, HttpPostRequestParams request, ICredentials? credentials = null);
}

public class HttpClient : IHttpClient
{
    private static readonly ILogger Logger = LoggerFactory.Create<HttpClient>();

    public string Get(Uri uri, HttpRequestParams request, ICredentials? credentials = null)
    {
        var stopwatch = Stopwatch.StartNew();

        using var webClient = new WebClient();

        webClient.Credentials = credentials;
        webClient.Encoding    = request.Encoding;

        foreach (var kvp in request.QueryParameters)
        {
            webClient.QueryString.Add(kvp.Key, kvp.Value);
        }

        var result = webClient.DownloadString(uri);
            
        stopwatch.Stop();
                
        if (Logger.IsDebugEnabled)
            Logger.Debug("GET {Uri} took {Elapsed}", uri.ToString(), stopwatch.Elapsed);
            
        return result;
    }

    public HttpResponse HttpGet(Uri uri, HttpRequestParams request, ICredentials? credentials = null)
    {
        var stopwatch = Stopwatch.StartNew();
            
        try
        {
            using var webClient = new WebClient();

            webClient.Credentials = credentials;
            webClient.Encoding    = request.Encoding;

            foreach (var kvp in request.QueryParameters)
            {
                webClient.QueryString.Add(kvp.Key, kvp.Value);
            }

            var response = webClient.DownloadString(uri);

            stopwatch.Stop();
                
            if (Logger.IsDebugEnabled)
                Logger.Debug("GET {Uri} took {Elapsed}", uri.ToString(), stopwatch.Elapsed);
                
            return new HttpResponse(isFailure: false, response);
        }
        catch (WebException ex) when (ex.Response is HttpWebResponse { StatusCode: HttpStatusCode.BadRequest } httpResponse)
        {
            using var responseStream = httpResponse.GetResponseStream()!;
            using var streamReader   = new StreamReader(responseStream);

            var response = streamReader.ReadToEnd();

            stopwatch.Stop();
                
            if (Logger.IsDebugEnabled)
                Logger.Debug("GET {Uri} took {Elapsed}", uri.ToString(), stopwatch.Elapsed);

            return new HttpResponse(isFailure: true, response);
        }
    }

    public string Post(Uri uri, HttpPostRequestParams request, ICredentials? credentials = null)
    {
        var stopwatch = Stopwatch.StartNew();

        using var webClient = new WebClient();

        webClient.Headers = new WebHeaderCollection();

        webClient.Credentials = credentials;
        webClient.Encoding    = request.Encoding;

        foreach (string key in request.Headers)
        {
            webClient.Headers[key] = request.Headers[key];
        }

        foreach (var kvp in request.QueryParameters)
        {
            webClient.QueryString.Add(kvp.Key, kvp.Value);
        }

        var result = webClient.UploadString(uri, request.Data);
            
             
        stopwatch.Stop();
                
        if (Logger.IsDebugEnabled)
            Logger.Debug("POST {Uri} took {Elapsed}", uri.ToString(), stopwatch.Elapsed);
            
        return result;
    }

    public HttpResponse HttpPost(Uri uri, HttpPostRequestParams request, ICredentials? credentials = null)
    {
        var stopwatch = Stopwatch.StartNew();

        try
        {
            using var webClient = new WebClient();

            webClient.Headers = new WebHeaderCollection();

            webClient.Credentials = credentials;
            webClient.Encoding    = request.Encoding;

            foreach (string key in request.Headers)
            {
                webClient.Headers[key] = request.Headers[key];
            }

            foreach (var kvp in request.QueryParameters)
            {
                webClient.QueryString.Add(kvp.Key, kvp.Value);
            }

            var response = webClient.UploadString(uri, request.Data);

            stopwatch.Stop();
                
            if (Logger.IsDebugEnabled)
                Logger.Debug("POST {Uri} took {Elapsed}", uri.ToString(), stopwatch.Elapsed);

            return new HttpResponse(isFailure: false, response);
        }
        catch (WebException ex) when (ex.Response is HttpWebResponse { StatusCode: HttpStatusCode.BadRequest } httpResponse)
        {
            using var responseStream = httpResponse.GetResponseStream()!;
            using var streamReader   = new StreamReader(responseStream);

            var response = streamReader.ReadToEnd();

            stopwatch.Stop();
                
            if (Logger.IsDebugEnabled)
                Logger.Debug("POST {Uri} took {Elapsed}", uri.ToString(), stopwatch.Elapsed);

            return new HttpResponse(isFailure: true, response);
        }
    }
}