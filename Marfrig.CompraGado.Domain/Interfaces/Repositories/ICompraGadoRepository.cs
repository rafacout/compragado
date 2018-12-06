using Marfrig.CompraGado.Domain.Entities;
using System.Collections.Generic;

namespace Marfrig.CompraGado.Domain.Interfaces.Repositories
{
    public interface ICompraGadoRepository : IRepositoryBase<Entities.CompraGado>
    {
        IEnumerable<Entities.CompraGado> GetByFilter(FiltroCompraGado filtro);
    }
}
