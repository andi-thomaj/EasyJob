using System.Linq;
using System.Reflection;
using Autofac;
using EasyJob.Application.Contracts.Persistence;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace EasyJob.Application
{
    public class ApplicationAutofacServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            /*var mediatRTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.ToString().EndsWith("Query"));
            mediatRTypes.Select(type => builder.RegisterMediatR(type.Assembly)).ToList();*/
            //builder.RegisterMediatR(Assembly.GetExecutingAssembly());
            //builder.RegisterMediatR(Assembly.GetExecutingAssembly()).RegisterType<Mediator>().As<IMediator>().PropertiesAutowired();
            
        }
    }
}