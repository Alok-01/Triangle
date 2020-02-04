using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triangle.IdentityWebServer
{
    public static class Configuration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(), // If Do not want it
            new IdentityResource
            {
                Name = "rc.naniscope", // this scope should be defined in client allowedScope properties chekc GetClient Method
                UserClaims =
                {
                    "rc.nannie"  // Remember Claim must exsit 
                }
            }
        };

        public static IEnumerable<ApiResource> GetApis() => new List<ApiResource>
        {
            new ApiResource("ApiOne", new string[] { "rc.api.nannie" }),
            new ApiResource("ApiTwo", new string[] { "rc.api.nannie" }),
        };

        public static IEnumerable<Client> GetClients() => new List<Client>
        {
            new Client
            {
                ClientId = "client_id", ClientSecrets = { new Secret("client_secret".ToSha256()) },
                AllowedScopes ={
                    "ApiOne"
                }

                , AllowedGrantTypes = GrantTypes.ClientCredentials // is machine to machine credential
            },
            new Client
            {
                ClientId = "client_id_mvc", ClientSecrets = { new Secret("client_secret_mvc".ToSha256()) },
                AllowedScopes ={
                    "ApiOne", "ApiTwo",
                    IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                    "rc.naniscope"
                },
                AllowedGrantTypes = GrantTypes.Code,
                AllowOfflineAccess = true,
                RedirectUris = {"https://localhost:44393/signin-oidc" }, // MvcClient Endpoint 
                PostLogoutRedirectUris =  {"https://localhost:44393/Home/Index" },
                RequireConsent = false // https://localhost:44305/consent ?  disabled the consent form
            }
        };
    }
}
