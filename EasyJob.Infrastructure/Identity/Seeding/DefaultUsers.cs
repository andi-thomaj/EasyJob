﻿using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EasyJob.Application.Contracts.Identity;
using EasyJob.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace EasyJob.Infrastructure.Identity.Seeding
{
    public static class DefaultUsers
    {
        public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            var defaultAdmin = new User
            {
                UserName = "andi.dev94@gmail.com",
                Email = "andi.dev94@gmail.com",
                EmailConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultAdmin.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultAdmin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultAdmin, "123456");
                    await userManager.AddToRoleAsync(defaultAdmin, "Admin");
                    await SeedClaimsForAdmin(roleManager);
                }
            }
        }

        private async static Task SeedClaimsForAdmin(this RoleManager<IdentityRole<int>> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            await roleManager.AddPermissionClaim(adminRole, "Killing");
        }

        public static async Task AddPermissionClaim(this RoleManager<IdentityRole<int>> roleManager, IdentityRole<int> role,
            string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsForModule(ControllerName.Posts);
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
        }
    }
}