using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeAuth.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FakeAuth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            //Call the config for authentication/authorization
            ConfigureAuth(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //set your app to use authentication and authorization middlewares
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        
        //method is virtual so we can override it in TestStartup.cs
        protected virtual void ConfigureAuth(IServiceCollection services)
        {
            //configure authentication via JwtConfig.cs using your oidc servers details as params from e.g. env variables, vaults etc.
            services.ConfigureJwtAuthentication(options =>
            {
                options.Audience = "dummyAudience";
                options.TokenValidationParameters.ValidAudience = options.Audience;
                options.Authority = "dummyAuthority";
                options.TokenValidationParameters.ValidIssuer = "dummyIssuer";
            });
            
            //configure and add the Authorization part via JwtConfig.cs
            services.ConfigureJwtAuthorization();
        }
    }
}