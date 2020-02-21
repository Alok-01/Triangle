using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Net.Http.Headers;

namespace Triangle.MvcClient.Common
{
    public class ClientUtilityController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientUtilityController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<string> GenerateAccessToken()
        {
            var access_token = await HttpContext.GetTokenAsync("access_token");
            return access_token;
        }


        public async Task<HttpResponseMessage> ApiPostAsync(string uri, object vm, string nameInstance)
        {
            var accessToken = await this.GenerateAccessToken();
            var apiOneClient = _httpClientFactory.CreateClient(nameInstance);
            //var request = new HttpRequestMessage(HttpMethod.Post, uri);
            //request.Content = new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json");

            apiOneClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiOneClient.DefaultRequestHeaders.Accept.Clear();
            apiOneClient.SetBearerToken(accessToken);
            HttpRequestMessage request = BuidRequestContent(uri, vm);
            var response = await apiOneClient.PostAsync(uri, request.Content);
            return response;
        }

        private static HttpRequestMessage BuidRequestContent(string uri, object vm)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json");
            return request;
        }

        public async Task<HttpResponseMessage> ApiGetAsync(string uri)
        {
            var accessToken = await this.GenerateAccessToken();
            var apiOneClient = _httpClientFactory.CreateClient();

            apiOneClient.SetBearerToken(accessToken);
            var response = await apiOneClient.GetAsync(uri);

            return response;
        }

        public async Task<JwtSecurityToken> ReadAccessToken()
        {
            var accessToken = await GenerateAccessToken();
            var _accessToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            return _accessToken;
        }

        public async Task<JwtSecurityToken> IdToken()
        {
            var idToken = await HttpContext.GetTokenAsync("id_token");
            var _idToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);
            return _idToken;
        }

        public async Task<string> GetRefershToken()
        {
            var refresh_Token = await HttpContext.GetTokenAsync("refresh_token");
            return refresh_Token;
        }
    }
}
