using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using ToDoAPI;
using ToDoAPI.Services;

public class AuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IUserHandler _userHandler;

    public AuthenticationHandler(
        IUserHandler userHandler,
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock

        ) : base(options, logger, encoder, clock)
    {
        _userHandler = userHandler;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var path = Request.Path.ToString();

        if (path == $"/api/User/CreateUser" || path == $"/api/User/Login")
        {
            return AuthenticateResult.NoResult();
        }

        Guid userId;

        try
        {
            userId = Guid.Parse(UserDictionary.userId["UserId"]);
        }
        catch (Exception)
        {

            return AuthenticateResult.Fail("Not logged in");
        }

        var claims = new[] { new Claim("UserId", userId.ToString()) };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);
        return AuthenticateResult.Success(ticket);
    }
}





