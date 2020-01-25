using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FakeAuthIntTest.FakeAuthHelpers
{
    public class FakeAuthenticationHandler : AuthenticationHandler<FakeAuthOptions>
    {
        public FakeAuthenticationHandler(IOptionsMonitor<FakeAuthOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authTicket = new AuthenticationTicket(
                new ClaimsPrincipal(Options.Identity),
                new AuthenticationProperties(),
                FakeAuthStartup.FakeScheme
            );
            return Task.FromResult(AuthenticateResult.Success(authTicket));
        }
    }
}