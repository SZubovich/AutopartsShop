using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutopartsShop.Models;

namespace AutopartsShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DefaultPageModel model = new DefaultPageModel();
            model.Categories = new List<string> { "Test123", "fegegg" };

            return View(model);
        }

        public IActionResult Contacts()
        {
            DefaultPageModel model = new DefaultPageModel();
            model.Categories = new List<string> { "Test123", "jdjjjjjjjjjjjj" };

            return View(model);
        }

        public IActionResult Delivery()
        {
            DefaultPageModel model = new DefaultPageModel();
            model.Categories = new List<string> { "Test123", "jdjjjjjjjjjjjj" };

            return View(model);
        }
        
        public IActionResult Guarantee()
        {
            DefaultPageModel model = new DefaultPageModel();
            model.Categories = new List<string> { "Test123", "jdjjjjjjjjjjjj" };

            return View(model);
        }

        public IActionResult Privacy()
        {
            DefaultPageModel model = new DefaultPageModel();
            model.Categories = new List<string> { "Test123", "jdjjjjjjjjjjjj" };

            return View(model);
        }

        public IActionResult Payment()
        {
            DefaultPageModel model = new DefaultPageModel();
            model.Categories = new List<string> { "Test123", "jdjjjjjjjjjjjj" };

            return View(model);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
