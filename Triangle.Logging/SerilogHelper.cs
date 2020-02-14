using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Enrichers.AspnetcoreHttpcontext;

namespace Triangle.Logging
{
    /// <summary>
    /// Serillogger Helper
    /// </summary>
    public static class SerilogHelper
    {
        /// <summary>
        /// WithTriangleSerilogConfiguration used in Programmer.cs File in API/Client/Identity
        /// </summary>
        /// <param name="loggerConfig"></param>
        /// <param name="provider"></param>
        /// <param name="config"></param>
        public static void WithTriangleSerilogConfiguration(this LoggerConfiguration loggerConfig, IServiceProvider provider, IConfiguration config)
        {
            var elasticsearchUri = config["Logging:ElasticsearchUri"];
            var elasticIndexRoot = config["Logging:ElasticIndexFormatRoot"];
            var rollingFileName = config["Logging:RollingFileName"];
            var elasticBufferRoot = config["Logging:ElasticBufferRoot"];

            var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;

            loggerConfig
                .ReadFrom.Configuration(config)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName() //NuGet Pck Serilog.Enrichers.Environment Enrich Serilog log events with properties from System.Environment.
                .Enrich.WithProperty("Assembly", assemblyName)
                .Enrich.WithAspnetcoreHttpcontext(provider, GetContextInfo)
                 .WriteTo.File(rollingFileName);
                
        }

        /// <summary>
        /// Get ContextInfor
        /// </summary>
        /// <param name="hca"></param>
        /// <returns></returns>
        private static ContextInformation GetContextInfo(IHttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext == null) return null;

            return new ContextInformation
            {
                RemoteIpAddress = httpContext.Connection.RemoteIpAddress.ToString(),
                Host = httpContext.Request.Host.ToString(),
                Method = httpContext.Request.Method,
                Protocol = httpContext.Request.Protocol,
                UserInfo = GetUserInfo(httpContext.User),
            };
        }

        private static UserInformation GetUserInfo(ClaimsPrincipal ctxUser)
        {
            var user = ctxUser.Identity;
            if (user?.IsAuthenticated != true) return null;

            //var excludedClaims = new List<string>
            //{ "nbf", "exp", "auth_time", "amr", "sub", "at_hash",
            //    "s_hash", "sid", "name", "preferred_username" };

            const string userIdClaimType = "sub";
            const string userNameClaimType = "name";

            var userInfo = new UserInformation
            {
                UserId = ctxUser.Claims.FirstOrDefault(a => a.Type == userIdClaimType)?.Value,
                UserName = ctxUser.Claims.FirstOrDefault(a => a.Type == userNameClaimType)?.Value,
                UserClaims = new Dictionary<string, List<string>>()
            };
            foreach (var distinctClaimType in ctxUser.Claims
                //.Where(a => excludedClaims.All(ex => ex != a.Type))
                .Select(a => a.Type)
                .Distinct())
            {
                userInfo.UserClaims[distinctClaimType] = ctxUser.Claims
                    .Where(a => a.Type == distinctClaimType)
                    .Select(c => c.Value)
                    .ToList();
            }

            return userInfo;
        }
    }
}
