using System;
using EasyJob.Application.Contracts.Persistence;
using EasyJob.Domain.Entities;
using EasyJob.Persistence.Context;
using EasyJob.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyJob.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<EasyJobIdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            services.AddIdentity<User, IdentityRole<int>>(o =>
                {
                    o.Lockout.AllowedForNewUsers = false;
                    o.Lockout.MaxFailedAccessAttempts = 10;
                    o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                    o.User.RequireUniqueEmail = false;
                    o.SignIn.RequireConfirmedEmail = false;
                    o.Password.RequireDigit = false;
                    o.Password.RequiredLength = 6;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequiredUniqueChars = 0;
                    o.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<EasyJobIdentityContext>()
                .AddUserStore<UserStore<User, IdentityRole<int>, EasyJobIdentityContext, int>>()
                .AddRoleManager<RoleManager<IdentityRole<int>>>()
                .AddUserManager<UserManager<User>>()
                .AddRoleValidator<RoleValidator<IdentityRole<int>>>()
                .AddRoles<IdentityRole<int>>()
                .AddSignInManager<SignInManager<User>>()
                .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<User>>()
                .AddDefaultTokenProviders();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}