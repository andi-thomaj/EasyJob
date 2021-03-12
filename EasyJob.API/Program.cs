using System;
using System.Threading.Tasks;
using EasyJob.Infrastructure.Identity.Seeding;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EasyJob.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    /*var userManager = services.GetRequiredService<UserManager<UserEntity>>();*/
                    /*var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();

                    await DefaultRoles.SeedAsync(roleManager);*/
                    /*await DefaultUsers.SeedAsync(userManager, roleManager);*/
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            await host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}