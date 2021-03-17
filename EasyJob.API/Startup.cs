using System.Reflection;
using Autofac;
using EasyJob.API.Controllers;
using EasyJob.API.CustomJSONFormatters;
using EasyJob.API.StartupServices;
using EasyJob.Application;
using EasyJob.Infrastructure;
using EasyJob.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EasyJob.API
{
    public class Startup
    {
        public IConfigurationRoot ConfigurationRoot { get; set; }
        public ILifetimeScope AutofacContainer { get; set; }
        private readonly IWebHostEnvironment _environment;

        public Startup(IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.ConfigurationRoot = builder.Build();
            _environment = environment;
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ApplicationAutofacServiceModule());
            builder.RegisterModule(new InfrastructureAutofacServiceModule());
            builder.RegisterModule(new PersistenceAutofacServiceModule());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.IsSubclassOf(typeof(BaseApiController)))
                .PropertiesAutowired();
        }

        public void ConfigureServices(IServiceCollection services)
        {
   
            services.AddControllers()
                .AddControllersAsServices()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                });
            

            services
                .AddApplicationServices()
                .AddInfrastructureServices(ConfigurationRoot)
                .AddPersistenceServices(ConfigurationRoot)
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

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}