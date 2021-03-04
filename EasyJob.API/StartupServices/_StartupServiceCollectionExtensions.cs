using System.Reflection;
using EasyJob.BusinessLayer.AutoMapperProfile;
using EasyJob.BusinessLayer.FluentValidationServices;
using EasyJob.BusinessLayer.MailServices;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EasyJob.API.StartupServices
{
    public static partial class StartupServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserValidator>());
            
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MapperProfile)));
            services.AddScoped<IMailService, MailService>();

            return services;
        }
    }
}