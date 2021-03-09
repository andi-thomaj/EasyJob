using EasyJob.BusinessLayer._DataAccessServices.PostsService;
using EasyJob.BusinessLayer._Repositories.PostsRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EasyJob.API.StartupServices
{
    public static partial class StartupServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoriesAndServices(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            
            services.AddScoped<IPostService, PostService>();
            
            
            return services;
        }
    }
}