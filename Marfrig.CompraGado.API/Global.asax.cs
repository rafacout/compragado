using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace Marfrig.CompraGado.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureSimpleInjector();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperConfig.MappingProfile>();
            });

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private static void ConfigureSimpleInjector()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            IoC.IoCConfiguration.Configure(container);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
