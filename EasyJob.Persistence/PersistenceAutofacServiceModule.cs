using System.Reflection;
using Autofac;
using EasyJob.Application.Contracts.Persistence;
using EasyJob.Persistence.Repositories;

namespace EasyJob.Persistence
{
    public class PersistenceAutofacServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.IsClosedTypeOf(typeof(BaseRepository<>)) || t.IsSubclassOf(typeof(BaseRepository<>)))
                .PropertiesAutowired();
        }
    }
}