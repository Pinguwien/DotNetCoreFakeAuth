using System;
using Microsoft.AspNetCore.Authentication;

namespace FakeAuthIntTest.FakeAuthHelpers
{
    public static class FakeAuthenticationBuilder
    {
        private static string displayName = "Fake Auth";
        
        public static AuthenticationBuilder AddFakeAuthentication(this AuthenticationBuilder builder,
            Action<FakeAuthOptions> options)
        {
            return builder.AddScheme<FakeAuthOptions, FakeAuthenticationHandler>(FakeAuthStartup.FakeScheme,
                displayName, options);
        }
    }
}