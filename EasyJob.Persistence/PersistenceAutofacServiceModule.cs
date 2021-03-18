using System.Reflection;
using Autofac;
using EasyJob.Application.Contracts.Persistence;
using EasyJob.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EasyJob.Persistence
{
    public class PersistenceAutofacServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterGeneric(typeof(BaseRepository<>))
                .As(typeof(IAsyncRepository<>))
                .PropertiesAutowired();
            builder.RegisterType<PostRepository>().As<IPostRepository>().PropertiesAutowired();
        }
    }
}