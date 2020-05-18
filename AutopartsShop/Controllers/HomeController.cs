using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutopartsShop.Models;

namespace AutopartsShop.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            DefaultPageModel model = DefaultModelCreate();

            return View(model);
        }

        [Authorize]
        public IActionResult Contacts()
        {
            DefaultPageModel model = DefaultModelCreate();

            return View(model);
        }

        [Authorize]
        public IActionResult Delivery()
        {
            DefaultPageModel model = DefaultModelCreate();

            return View(model);
        }

        [Authorize]
        public IActionResult Guarantee()
        {
            DefaultPageModel model = DefaultModelCreate();

            return View(model);
        }

        [Authorize]
        public IActionResult Privacy()
        {
            DefaultPageModel model = DefaultModelCreate();

            return View(model);
        }

        [Authorize]
        public IActionResult Payment()
        {
            DefaultPageModel model = DefaultModelCreate();

            return View(model);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private DefaultPageModel DefaultModelCreate()
        {
            DefaultPageModel pageModel = null;

            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                pageModel = new DefaultPageModel();

                pageModel.User = new UserModel
                {
                    Login = User.Identity.Name,
                    Permissions = new PermissionModel { Admin = true }
                };
            }

            return pageModel;
        }
    }
}
