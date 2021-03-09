using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EasyJob.DataLayer.Entities.Seeding
{
    public static class DefaultUsers
    {
        public static async Task SeedAsync(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultAdmin = new UserEntity
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
                }
            }
        }
    }
}