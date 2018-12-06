using Marfrig.CompraGado.Domain.Entities;
using Marfrig.CompraGado.Domain.Interfaces.Repositories;
using Marfrig.CompraGado.Domain.Interfaces.Services;

namespace Marfrig.CompraGado.Domain.Services
{
    public class CompraGadoService : ServiceBase<Entities.CompraGado>, ICompraGadoService
    {
        private readonly ICompraGadoRepository _animalRepository;

        public CompraGadoService(ICompraGadoRepository animalRepository)
            : base(animalRepository)
        {
            _animalRepository = animalRepository;
        }
    }
}
