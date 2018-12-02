using DutchApp.Data.Entities;
using DutchApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchApp.Controllers
{
    public class AccountController : Controller
    {
        private ILogger<AccountController> _logger;
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;

        public AccountController(ILogger<AccountController> logger,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "App");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username,
                    model.Password,
                    model.RememberMe,
                    false);

                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    RedirectToAction("Verbs", "App");
                }
            }

            ModelState.AddModelError("", "Failed to login");
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Register()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = _userManager.CreateAsync()
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "App");
        }

    }
}
