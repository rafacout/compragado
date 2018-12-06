using Marfrig.CompraGado.Application.Application;
using Marfrig.CompraGado.Application.Interfaces;
using Marfrig.CompraGado.Data.Context;
using Marfrig.CompraGado.Data.Repositories;
using Marfrig.CompraGado.Domain.Interfaces.Repositories;
using Marfrig.CompraGado.Domain.Interfaces.Services;
using Marfrig.CompraGado.Domain.Services;
using SimpleInjector;

namespace Marfrig.CompraGado.IoC
{
    public static class IoCConfiguration
    {
        public static void Configure(Container container)
        {
            ConfigureDomain(container);
            ConfigureData(container);
            ConfigureApplication(container);
        }

        private static void ConfigureApplication(Container container)
        {
            container.Register<IAnimalApplication, AnimalApplication>(Lifestyle.Scoped);
            container.Register<IPecuaristaApplication, PecuaristaApplication>(Lifestyle.Scoped);
            container.Register<ICompraGadoApplication, CompraGadoApplication>(Lifestyle.Scoped);

            container.Register<IAnimalRepository, AnimalRepository>(Lifestyle.Scoped);
            container.Register<IPecuaristaRepository, PecuaristaRepository>(Lifestyle.Scoped);
            container.Register<ICompraGadoRepository, CompraGadoRepository>(Lifestyle.Scoped);
        }

        private static void ConfigureData(Container container)
        {
            container.Register<MarfrigContext>(Lifestyle.Scoped);
        }

        private static void ConfigureDomain(Container services)
        {
            services.Register<IAnimalService, AnimalService>(Lifestyle.Scoped);
            services.Register<IPecuaristaService, PecuaristaService>(Lifestyle.Scoped);
            services.Register<ICompraGadoService, CompraGadoService>(Lifestyle.Scoped);
        }
    }
}
