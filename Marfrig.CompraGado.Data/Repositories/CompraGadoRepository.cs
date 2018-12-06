using Marfrig.CompraGado.Data.Context;
using Marfrig.CompraGado.Domain.Entities;
using Marfrig.CompraGado.Domain.Interfaces.Repositories;

namespace Marfrig.CompraGado.Data.Repositories
{
    public class CompraGadoRepository : RepositoryBase<Domain.Entities.CompraGado>, ICompraGadoRepository
    {
        private readonly MarfrigContext _context;

        public CompraGadoRepository(MarfrigContext context) 
            : base(context)
        {
            _context = context;
        }
    }
}
