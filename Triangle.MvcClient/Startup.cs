using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace Triangle.MvcClient
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            this._config = config;
        }

        /// <summary>
        /// COnfugration Services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(
                config =>
                {
                    config.DefaultScheme = "Cookie";
                    config.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookie")
                .AddOpenIdConnect("oidc", config =>
                {
                    //options.SignInScheme = "Cookies"; //Let See on 14-Feb2020
                    config.Authority = "https://localhost:44305/"; // Identity Server
                    config.ClientId = "client_id_mvc";
                    config.ClientSecret = "client_secret_mvc";
                    config.SaveTokens = true;
                    config.ResponseType = "code";
                    config.SignedOutCallbackPath = "/Home/Index";
                    //options.UsePkce = true; //Let See on 14-Feb2020
                    config.ClaimActions.MapUniqueJsonKey("MapIngCoding", "rc.naniscope");
                    config.GetClaimsFromUserInfoEndpoint = true;

                    //Configure Scope
                    config.Scope.Clear();
                    config.Scope.Add("openid");
                    config.Scope.Add("profile");//Let See on 14-Feb2020
                    config.Scope.Add("rc.naniscope");
                    config.Scope.Add("ApiOne");
                    config.Scope.Add("offline_access");

                    //Let See on 14-Feb2020 Below
                    config.Events.OnTicketReceived = e =>
                    {
                        Log.Information("Login successfully completed for {UserName}.",
                            e.Principal.Identity.Name);
                        return Task.CompletedTask;
                    };
                });
            services.AddMediatR(typeof(Startup));
            services.AddHttpContextAccessor();
            services.AddHttpClient();
            //services.AddControllersWithViews();
            //Let See on 14-Feb2020 Below
            services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/Home/Error"); //Let See on 14-Feb2020 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
