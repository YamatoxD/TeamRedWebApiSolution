using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityExample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExample.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userMgr;
        private SignInManager<IdentityUser> signInMgr;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            userMgr = userManager;
            signInMgr = signInManager;
        }

        public async Task<IActionResult> Logout()
        {
            await signInMgr.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Login()
        {
            var result = await signInMgr.PasswordSignInAsync("TestUser2", "Test123!", false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "result is: " + result.ToString();
            }
            return View();
        }

        public async Task<IActionResult> Register()
        {
            try
            {
                ViewBag.Message = "User already exists";
                IdentityUser user = await userMgr.FindByNameAsync("TestUser2");
                if(user == null)
                {
                    user = new IdentityUser
                    {
                        UserName = "TestUser2",
                        Email = "TestUser2@test.com",
                        EmailConfirmed = true
                    };
                    IdentityResult result = await userMgr.CreateAsync(user, "Test123!");
                    ViewBag.Message = "User was created";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
    }
}
