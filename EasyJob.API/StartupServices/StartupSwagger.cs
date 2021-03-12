using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EasyJob.API.StartupServices
{
    public static class StartupSwagger
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "EasyJob.API", Version = "v1"});
            });

            return services;
        }
    }
}