using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Services;
using System.Threading.Tasks;
using AutopartsShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace AutopartsShop.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            LoginModel model = new LoginModel();
            model.Categories = new List<string> { "Test123", "jdjjjjjjjjjjjj" };

            return View("Test", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterModel loginModel)
        {
            string result = loginModel.Email;
            var length = result.Length;

            LoginModel model = new LoginModel();
            model.Categories = new List<string> { "Test123", "jdjjjjjjjjjjjj" };


            return View("Test", model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginModel model = new LoginModel();
            model.Categories = new List<string> { "Test123", "jdjjjjjjjjjjjj" };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel loginModel)
        {
            string result = loginModel.Login;
            var length = result.Length;

            LoginModel model = new LoginModel();
            model.Categories = new List<string> { "Test123", "jdjjjjjjjjjjjj" };
            //AccountService accountService = new AccountService();
            //accountService.Login(loginModel.Login, loginModel.Password);

            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}