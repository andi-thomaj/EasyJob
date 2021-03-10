using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EasyJob.DataLayer.Entities.Seeding
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole<int>> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole<int>("Admin"));
            await roleManager.CreateAsync(new IdentityRole<int>("Basic"));
        }
    }
}