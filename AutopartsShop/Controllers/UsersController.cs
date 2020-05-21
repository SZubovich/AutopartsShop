using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using BLL.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using AutopartsShop.Models;
using AutopartsShop.Mapper;

namespace AutopartsShop.Controllers
{
    public class UsersController : Controller
    {
        [Authorize(Roles ="ADMIN")]
        public ActionResult Index()
        {
            var userService = new AccountService();
            var users = userService.GetByCondition((x) => x.Role != null && x.Role.Name != "Customer");
            UsersListModel usersListModel = new UsersListModel();
            usersListModel.Users = new List<UserModel>();

            foreach (var user in users)
            {
                usersListModel.Users.Add(user.ToView());
            }

            return View(usersListModel);
        }

        public ActionResult Create()
        {
            UserModel model = new UserModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                AccountService accountService = new AccountService();
                accountService.Add(user.ToBLL());
            }

            var userService = new AccountService();
            var users = userService.GetByCondition((x) => x.Role != null && x.Role.Name != "Customer");
            UsersListModel usersListModel = new UsersListModel();
            usersListModel.Users = new List<UserModel>();

            foreach (var curUser in users)
            {
                usersListModel.Users.Add(curUser.ToView());
            }

            return View("Index", usersListModel);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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