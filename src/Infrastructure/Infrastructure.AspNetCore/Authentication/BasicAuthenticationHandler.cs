using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;

namespace Infrastructure.AspNetCore.Authentication;

public abstract class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    protected BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
                                  ILoggerFactory logger,
                                  UrlEncoder encoder,
                                  ISystemClock clock)
        : base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            Response.Headers.Add("WWW-Authenticate", "Basic");
            
            return AuthenticateResult.Fail("Missing Authorization Header");
        }

        string login;
        string password;
        try
        {
            var authHeader      = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter!);
            var credentials     = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, count: 2);
            login    = credentials[0];
            password = credentials[1];
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Authentication error");
            return AuthenticateResult.Fail(ex);
        }

        var claimsResult = await Authenticate(login, password);
        if (claimsResult.IsFailure)
            return claimsResult.Error;

        var claims = claimsResult.Value;

        var identity  = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket    = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }

    protected abstract Task<Result<IList<Claim>, AuthenticateResult>> Authenticate(string login, string password);
}