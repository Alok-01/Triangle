using System.Threading.Tasks;
using IdentityServer4.Services;
using Triangle.IdentityWebServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Triangle.IdentityWebServer.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IIdentityServerInteractionService _interactionService;
        private readonly UserManager<IdentityUser> _userManagerr;
        private readonly IHttpContextAccessor contextAccessor;
        private string _authenticatedUser;
        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IIdentityServerInteractionService interactionService, IHttpContextAccessor contextAccessor)
        {
            _userManagerr = userManager;
            _signInManager = signInManager;
            _interactionService = interactionService; //http://docs.identityserver.io/en/latest/reference/interactionservice.html
            this.contextAccessor = contextAccessor;
            _authenticatedUser = contextAccessor.HttpContext.User.Identity.Name;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {

            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
                //ExternalProviders = externalProviders
            });
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);
            if (string.IsNullOrEmpty(logoutRequest.PostLogoutRedirectUri))
            {
                return RedirectToAction("Index", "Home");
            }
            return Redirect(logoutRequest.PostLogoutRedirectUri);

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            //check model is valid 
            var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(vm.ReturnUrl);
            }
            else if (result.IsLockedOut)
            {

            }
            return View();
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var user = new IdentityUser(vm.UserName);
            var result = await _userManagerr.CreateAsync(user, vm.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Redirect(vm.ReturnUrl);
            }

            return View();
        }

        /// <summary>
        /// Login View
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View("Login");
        }
    }
}