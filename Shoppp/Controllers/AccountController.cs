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

namespace OnlineShopping.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 RoleManager<IdentityRole> roleManager
                                 )
        {
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register() => View();
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Content("You're shit nigga");
            }
            var tryToRegister = await userManager.CreateAsync(new AppUser { UserName = model.UserName, FirstName = model.FirstName, LastName = model.LastName }, model.Password);
            if (tryToRegister.Succeeded)
            {
                var postojiRola = await roleManager.RoleExistsAsync("CRUD");
                if (!postojiRola)
                {
                    var role = await roleManager.CreateAsync(new IdentityRole { Name = "CRUD" });
                }
                var user = await userManager.FindByNameAsync(model.UserName);
                await userManager.AddToRoleAsync(user, "CRUD");
                await userManager.AddClaimAsync(user, new Claim("CRUD", "Kreiraj"));
                return RedirectToAction("Index", "Home");
            }

            return Content("Shit happend");
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
                return Content("You're shit nigga");
            }
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                var user = await userManager.GetUserAsync(User);
                HttpContext.Session.SetUser(user);
                return RedirectToAction("Index", "Home");
            }
            return Content("Shit happend");
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
            return RedirectToAction("Index","Home");
        }
    }
}
