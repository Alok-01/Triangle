using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Threading.Tasks;
using Triangle.ApiStudent.Middleware;
using Triangle.Common;
using Triangle.StudentBusinessServices;
using Triangle.StudentBusinessServicesInterface;
using Triangle.StudentModelServices;
using Triangle.StudentModelServicesInterface;
using Triangle.StudentRepositories;
using Triangle.StudentRepositoriesInterface;

namespace Triangle.ApiStudent
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
            Configuration.GetSection("ConnectionStrings").Bind("DatabaseConnectionString");
            var strConnection = Configuration.GetConnectionString("DatabaseConnectionString");
            ConnectionFactory.Initialize("StudentV4Db", strConnection);
            services.AddMediatR(typeof(Startup));
            services.AddTransient<IStudentModelService, StudentModelService>();
            services.AddTransient<IStudentBusinessService, StudentBusinessService>();
            services.AddTransient<IStudenteRepository, StudenteRepository>();
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer",
                   config =>
                   {
                       config.Authority = "https://localhost:44305/";
                       config.Audience = "ApiOne";
                       config.Events = new JwtBearerEvents
                       {
                           OnForbidden = e =>
                           {
                               Log.Warning("API access was forbidden!");
                               return Task.FromResult(e);
                           },
                           OnAuthenticationFailed = e =>
                           {
                               Log.Warning(e.Exception, "Authentication Failed!");
                               return Task.FromResult(e);
                           }
                       };
                   });
            services.AddHttpContextAccessor();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseApiExceptionHandler();  // custom middleware
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
