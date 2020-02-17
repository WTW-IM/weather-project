using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewProject
{
    public partial class Startup
    {
        private void ConfigureAuth(IServiceCollection services)
        {
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
               .AddIdentityServerAuthentication(options =>
               {
                   options.Authority = "https://demo.identityserver.io/";
                   options.RequireHttpsMetadata = false;
                   options.ApiName = "api";
               });
        }
    }
}
