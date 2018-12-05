using Marfrig.CompraGado.Data.Context;
using Marfrig.CompraGado.Domain.Entities;
using Marfrig.CompraGado.Domain.Interfaces.Repositories;

namespace Marfrig.CompraGado.Data.Repositories
{
    public class AnimalRepository : RepositoryBase<Animal>, IAnimalRepository
    {
        private readonly MarfrigContext _context;

        public AnimalRepository(MarfrigContext context) 
            : base(context)
        {
            _context = context;
        }
    }
}
