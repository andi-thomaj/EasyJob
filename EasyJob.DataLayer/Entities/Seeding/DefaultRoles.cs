using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EasyJob.DataLayer.Entities.Seeding
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("BasicUser"));
        }
    }
}