using Marfrig.CompraGado.Data.Context;
using Marfrig.CompraGado.Domain.Entities;
using Marfrig.CompraGado.Domain.Interfaces.Repositories;

namespace Marfrig.CompraGado.Data.Repositories
{
    public class PecuaristaRepository : RepositoryBase<Pecuarista>, IPecuaristaRepository
    {
        private readonly MarfrigContext _context;

        public PecuaristaRepository(MarfrigContext context) 
            : base(context)
        {
            _context = context;
        }
    }
}
