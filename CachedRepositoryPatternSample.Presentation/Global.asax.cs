using CachedRepositoryPatternSample.Presentation.IocConfiguration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Web.Http;

namespace CachedRepositoryPatternSample.Presentation
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;

        protected void Application_Start()
        {
            ConfigureWindsor(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(c => WebApiConfig.Register(c, IoC.Container));
        }
        public static void ConfigureWindsor(HttpConfiguration configuration)
        {
            IoC.Container = new WindsorContainer();
            IoC.Container.Install(FromAssembly.This());
            IoC.Container.Kernel.Resolver.AddSubResolver(new CollectionResolver(IoC.Container.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(IoC.Container);
            configuration.DependencyResolver = dependencyResolver;
        }

        protected void Application_End()
        {
            IoC.Container.Dispose();
            base.Dispose();
        }
    }
}
