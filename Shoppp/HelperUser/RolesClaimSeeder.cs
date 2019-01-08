using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OnlineShopping.Data;

namespace OnlineShopping.HelperUser
{
    public static class RolesClaimSeeder
    {
        public async static Task InitializeRolesAndClaims(ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();
            if (await roleManager.FindByNameAsync("Admin") == null)
            {
                var role = new IdentityRole { Name = "Admin" };
                var res = await roleManager.CreateAsync(role);
            }
            if (await roleManager.FindByNameAsync("User") == null)
            {
                var res = await roleManager.CreateAsync(new IdentityRole { Name = "User" });
            }
            if (await userManager.FindByNameAsync("admin") == null)
            {
                var adminUser = new AppUser
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "admin",
                    Email = "admin@hotmail.com"
                };
                var result= await userManager.CreateAsync(adminUser, "adminadmin123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
