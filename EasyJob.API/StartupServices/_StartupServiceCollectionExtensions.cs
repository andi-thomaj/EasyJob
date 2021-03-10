using System.Reflection;
using AutoMapper.Configuration;
using EasyJob.API.CustomJSONFormatters;
using EasyJob.BusinessLayer.AutoMapperProfile;
using EasyJob.BusinessLayer.FluentValidationServices;
using EasyJob.BusinessLayer.MailServices;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace EasyJob.API.StartupServices
{
    public static partial class StartupServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserValidator>());
            
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MapperProfile)));
            services.AddScoped<IMailService, MailService>();

            return services;
        }
    }
}