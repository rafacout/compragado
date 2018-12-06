using Marfrig.CompraGado.Data.Context;
using Marfrig.CompraGado.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Marfrig.CompraGado.Data.Repositories
{
    public class CompraGadoRepository : ICompraGadoRepository
    {
        private readonly MarfrigContext _context;

        public CompraGadoRepository(MarfrigContext context) 
        {
            _context = context;
        }

        public  void Add(Domain.Entities.CompraGado obj)
        {
            _context.CompraGados.Add(obj);
            _context.SaveChanges();
        }

        public  IEnumerable<Domain.Entities.CompraGado> GetAll()
        {
            var _compraGados = _context.CompraGados
                .Include("Pecuarista")
                .Include("CompraGadoItens")
                .Include("CompraGadoItens.Animal")
                .ToList();

            return _compraGados;
        }

        public Domain.Entities.CompraGado GetById(long id)
        {
            return _context.CompraGados.Find(id);
        }

        public  void Remove(Domain.Entities.CompraGado obj)
        {
            _context.CompraGados.Remove(obj);
            _context.SaveChanges();
        }

        public  void Update(Domain.Entities.CompraGado obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
