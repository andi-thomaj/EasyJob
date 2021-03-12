using EasyJob.Application.Contracts.Infrastructure;
using EasyJob.Application.Models.Mail;
using EasyJob.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyJob.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}