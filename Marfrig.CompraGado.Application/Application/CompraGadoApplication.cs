using Marfrig.CompraGado.Application.Interfaces;
using Marfrig.CompraGado.Domain.Entities;
using Marfrig.CompraGado.Domain.Interfaces.Services;

namespace Marfrig.CompraGado.Application.Application
{
    public class CompraGadoApplication : ApplicationBase<Domain.Entities.CompraGado>, ICompraGadoApplication
    {
        private readonly ICompraGadoService _animalService;

        public CompraGadoApplication(ICompraGadoService animalService)
            : base(animalService)
        {
            _animalService = animalService;
        }
    }
}
