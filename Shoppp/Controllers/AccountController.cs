using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.HelperUser;
using OnlineShopping.ViewModels;
using OnlineShopping.HelperUser;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace OnlineShopping.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register() => View();
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model,IFormFile picture)
        {
            if (!ModelState.IsValid)
            {
                return Content("Something went wrong");
            }
            var ms = new MemoryStream();
            picture.CopyTo(ms);
            var tryToRegister = await userManager.CreateAsync(new AppUser { UserName = model.UserName, FirstName = model.FirstName, LastName = model.LastName,Picture =ms.ToArray() }, model.Password);
            if (tryToRegister.Succeeded)
            {
                var user = await userManager.FindByNameAsync(model.UserName);

                var roleUser = roleManager.FindByNameAsync("User");
                await userManager.AddToRoleAsync(user,roleUser.Result.Name);
                return RedirectToAction("Index", "Admin");
            }

            return Content("Something went wrong");
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (signInManager.IsSignedIn(User)) RedirectToAction("Index","Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Content("Something went wrong");
            }
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                var user = await userManager.GetUserAsync(User);
                HttpContext.Session.SetUser(user);
                return RedirectToAction("Index", "Admin");
            }
            return Content("Something went wrong");
        }
        [HttpGet]
        public IActionResult Privacy() => View();
        [HttpGet]
        public IActionResult Contact() => Contact();
        public async Task<IActionResult> Logout()
        {
            if (signInManager.IsSignedIn(User))
            {
                await signInManager.SignOutAsync();
                HttpContext.Session.Clear();
            }
            return RedirectToAction("Index","Admin");
        }
    }
}
