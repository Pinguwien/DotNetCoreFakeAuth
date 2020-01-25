using System;
using System.Security.Claims;
using FakeAuth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FakeAuthIntTest.FakeAuthHelpers
{
    public class FakeAuthStartup : Startup
    {
        public static string FakeScheme = "FakeScheme";

        public FakeAuthStartup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void ConfigureAuth(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = FakeScheme;
                options.DefaultChallengeScheme = FakeScheme;
            }).AddFakeAuthentication(options => { /* override Identity for tests here if needed */ });
        }
    }
}