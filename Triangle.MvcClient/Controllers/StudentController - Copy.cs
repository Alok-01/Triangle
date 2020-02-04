using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcClient.Common;
using MvcClient.Models;
using Newtonsoft.Json;

namespace MvcClient.Controllers
{
    public class StudentControllerOld : ClientUtilityController//Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private static string apiOneUri = "https://localhost:44345/secretcreatestudent"; // ApiOne
        private static string apiStudentUri = "https://localhost:44345/student/secretcreatestudent"; // ApiOne
        private string _authenticatedUser;
        private readonly IHttpContextAccessor contextAccessor;

        public StudentControllerOld(IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            this.contextAccessor = contextAccessor;
            _authenticatedUser = contextAccessor.HttpContext.User.Identity.Name;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> Index(StudentRegistrationModel vm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(vm);
        //    }
        //    var access_token = await HttpContext.GetTokenAsync("access_token");
        //    var idToken = await HttpContext.GetTokenAsync("id_token");
        //    var refresh_Token = await HttpContext.GetTokenAsync("refresh_token");

        //    //var userClaim = User.Claims;
        //    var userClaim = User.Claims.ToList();
        //    //UserClaims properties dose not contain idtoken values, so need to mapp it. access_token is JSON format; 
        //    //so MVCCLient Setup file to configure 
        //    var _accessToken = new JwtSecurityTokenHandler().ReadJwtToken(access_token);
        //    var _idToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);

        //    var result = await PostSecertAsync(access_token, vm);
        //    return RedirectToAction("Index", "Home");
        //}

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(StudentRegistrationModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var access_token = await this.GenerateAccessToekn();
            var result = await this.ApiPosAsync(access_token, vm);
            //var result = await PostSecertAsync(access_token, vm);
            return RedirectToAction("Index", "Home");
        }
        public async Task<string> GetSecertAsync(string accessToken)
        {
            // retrieve secret data from apiOne webApi
            var apiOneClient = _httpClientFactory.CreateClient();

            apiOneClient.SetBearerToken(accessToken);
            var response = await apiOneClient.GetAsync(apiOneUri);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> PostSecertAsync(string accessToken, StudentRegistrationModel vm)
        {
            // retrieve secret data from apiOne webApi
            var apiOneClient = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Post, apiStudentUri);
            request.Content = new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json");
            apiOneClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiOneClient.DefaultRequestHeaders.Accept.Clear();
            apiOneClient.SetBearerToken(accessToken);
            var response = await apiOneClient.PostAsync(apiStudentUri, request.Content);
            var content = await response.Content.ReadAsStringAsync();
            //var response = await userApi.SendAsync(request);
            return content;
        }

        public async Task PostSecretAsync1(string accessToken, StudentRegistrationModel vm)
        {
            var userApi = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, apiOneUri);
            request.Content = new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json");

            var response = await userApi.SendAsync(request);

            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    var body = await response.Content.ReadAsAsync<LoginResponse>();
            //    return Ok(body);
            //}
            //return StatusCode((int)response.StatusCode);
        }
        //public async Task<ActionResult> GetSecertAsync(string accessToken, StudentRegistrationModel model)
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:8082/");
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.Accept.Clear();

        //    HttpResponseMessage response = await client.PostAsJsonAsync("api/CreateEmployee/PostEmployee", model);

        //    if (response.IsSuccessStatusCode == true)
        //    {
        //        return View();
        //    }

        //    return View();
        //}
    }
}
