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

        [HttpGet(Name = "Login")]
        public IActionResult LoginGet()
        {
            return View("Login");
        }

        [HttpPost(Name = "Login")]
        public async Task<IActionResult> LoginPost(string username, string password)
        {
            // TestUser2
            // Test123!

            try
            {
                var result = await signInMgr.PasswordSignInAsync(username, password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Result = "result is: " + result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
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


        public async Task<IActionResult> DeleteUser()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            IdentityUser user = await userMgr.GetUserAsync(currentUser);

            await Logout();
            
            await userMgr.DeleteAsync(user);
            return RedirectToAction("Index", "Home");
        }
    }
}
