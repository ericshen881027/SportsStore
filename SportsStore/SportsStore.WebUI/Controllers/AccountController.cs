﻿using System.Web.Mvc;
using SportsStore.WebUI.Infrastructure;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthProvider _authProvider;

        public AccountController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}