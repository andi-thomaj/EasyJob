using System;
using System.Reflection;
using System.Security.Claims;
using EasyJob.API.StartupServices;
using EasyJob.BusinessLayer.AutoMapperProfile;
using EasyJob.BusinessLayer.FluentValidationServices;
using EasyJob.DataLayer.Entities;
using EasyJob.DataLayer.Entities.Context;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EasyJob.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        

        public void ConfigureServices(IServiceCollection services)
        {
   
            services.AddDbContext<EasyJobIdentityContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<UserEntity, IdentityRole<int>>(o =>
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
                .AddUserStore<UserStore<UserEntity, IdentityRole<int>, EasyJobIdentityContext, int>>()
                .AddRoleManager<RoleManager<IdentityRole<int>>>()
                .AddUserManager<UserManager<UserEntity>>()
                .AddRoleValidator<RoleValidator<IdentityRole<int>>>()
                .AddRoles<IdentityRole<int>>()
                .AddSignInManager<SignInManager<UserEntity>>()
                .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<UserEntity>>()
                .AddDefaultTokenProviders();

            services
                .AddInfrastructureServices()
                .AddJwtConfiguration(_configuration)
                .AddRepositoriesAndServices()
                .AddSwaggerService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyJob.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers().RequireAuthorization(); });
        }
    }
}