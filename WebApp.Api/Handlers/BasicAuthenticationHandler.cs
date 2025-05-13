using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace WebApp.Api.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IConfiguration _configuration;

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock,IConfiguration configuration) : base(options, logger, encoder, clock)
        {
            _configuration = configuration;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string _username = _configuration["ApiBasicDetails:ClientId"];
            string _password = _configuration["ApiBasicDetails:ClientScecret"];

            try
            {
          

                var authHeader = System.Net.Http.Headers.AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var decryptedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter ?? ""));
                string[] userNamePassword = decryptedCredentials.Split(":");//admin:123456
                string username = userNamePassword[0];
                string password = userNamePassword[1];

                //if(!_username.Equals(username, StringComparison.OrdinalIgnoreCase) && password ==_password)
                //{
                //    throw new ArgumentException("Invalid Credentials");
                //}

                if ( !(_username.ToLower() == username.ToLower() && password == _password))
                {
                    throw new ArgumentException("Invalid Credentials");
                }

            }
            catch (Exception ex)
            {

                return AuthenticateResult.Fail($"Authentication Failed: {ex.Message}");

            }

            var claims = new[] { new Claim(ClaimTypes.Name, _username) };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}
