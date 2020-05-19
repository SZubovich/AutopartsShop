using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Services;
using System.Threading.Tasks;
using AutopartsShop.Models;
using AutopartsShop.Mapper;
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
            RegisterModel model = new RegisterModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                AccountService accountService = new AccountService();
                var user = new UserModel() { Login = registerModel.Email, Password = registerModel.Password };
                accountService.Add(user.ToBLL());
                user = accountService.Login(registerModel.Email, registerModel.Password).ToView();
                await Authenticate(user);
                return RedirectToAction("Index", "Home");
            }
            return View(registerModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginModel model = new LoginModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            string result = loginModel.Login;
            var length = result.Length;

            LoginModel model = new LoginModel();

            if (ModelState.IsValid)
            {
                AccountService accountService = new AccountService();
                var user = accountService.Login(loginModel.Login, loginModel.Password);

                if (user != null)
                {
                    await Authenticate(user.ToView());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Ведённые логин и/или пароль некорректны!");
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        private async Task Authenticate(UserModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, PermissionModel.GetRoleName(user.Permissions))
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}