using Autofac;
using EasyJob.Application.Contracts.Identity;
using EasyJob.Infrastructure.Identity;

namespace EasyJob.Infrastructure
{
    public class InfrastructureAutofacServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerDependency();
        }
    }
}