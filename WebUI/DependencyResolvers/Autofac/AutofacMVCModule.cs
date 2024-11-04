using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System.Reflection;
using WebUI.Services.Abstract;
using WebUI.Services.Concrete;
using Module = Autofac.Module;
namespace WebUI.DependencyResolvers.Autofac
{
    public class AutofacMVCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

            builder.RegisterType<MessageManager>().As<IMessageService>().SingleInstance();

        }
    }
}
