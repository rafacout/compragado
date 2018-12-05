using Marfrig.CompraGado.Domain.Entities;
using Marfrig.CompraGado.Domain.Interfaces.Repositories;
using Marfrig.CompraGado.Domain.Interfaces.Services;

namespace Marfrig.CompraGado.Domain.Services
{
    public class PecuaristaService : ServiceBase<Pecuarista>, IPecuaristaService
    {
        private readonly IPecuaristaRepository _pecuaristaRepository;

        public PecuaristaService(IPecuaristaRepository pecuaristaRepository)
            : base(pecuaristaRepository)
        {
            _pecuaristaRepository = pecuaristaRepository;
        }
    }
}
