using Marfrig.CompraGado.Application.Interfaces;
using Marfrig.CompraGado.Domain.Entities;
using Marfrig.CompraGado.Domain.Interfaces.Services;

namespace Marfrig.CompraGado.Application.Application
{
    public class PecuaristaApplication : ApplicationBase<Pecuarista>, IPecuaristaApplication
    {
        private readonly IPecuaristaService _pecuaristaService;

        public PecuaristaApplication(IPecuaristaService pecuaristaService) 
            : base(pecuaristaService)
        {
            _pecuaristaService = pecuaristaService;
        }
    }
}
