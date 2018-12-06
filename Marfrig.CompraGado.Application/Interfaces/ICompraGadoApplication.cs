using Marfrig.CompraGado.Domain.Entities;
using System.Collections.Generic;

namespace Marfrig.CompraGado.Application.Interfaces
{
    public interface ICompraGadoApplication : IApplicationBase<Domain.Entities.CompraGado>
    {
        IEnumerable<Domain.Entities.CompraGado> GetByFilter(FiltroCompraGado filtro);
    }
}
