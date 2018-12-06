using Marfrig.CompraGado.Domain.Entities;
using System.Collections.Generic;

namespace Marfrig.CompraGado.Domain.Interfaces.Services
{
    public interface ICompraGadoService : IServiceBase<Entities.CompraGado>
    {
        IEnumerable<Entities.CompraGado> GetByFilter(FiltroCompraGado filtro);
    }
}
