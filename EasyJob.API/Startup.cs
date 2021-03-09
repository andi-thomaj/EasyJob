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
            services.AddIdentity<UserEntity, IdentityRole>(o =>
                {
                    o.Lockout.AllowedForNewUsers = true;
                    o.Lockout.MaxFailedAccessAttempts = 10;
                    o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                    o.User.RequireUniqueEmail = true;
                    o.SignIn.RequireConfirmedEmail = true;
                    o.Password.RequireDigit = false;
                    o.Password.RequiredLength = 6;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequiredUniqueChars = 0;
                    o.Password.RequireNonAlphanumeric = false;
                })
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyTypes.Users.Manage, policy =>
                {
                    policy.RequireClaim(CustomClaimTypes.Permission, "Permission");
                });
            });
            
            services
                .AddInfrastructureServices()
                .AddJwtConfiguration(_configuration)
                .AddRepositoriesAndServices()
                .AddSwaggerGen();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}