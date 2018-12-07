using Marfrig.CompraGado.Data.Context;
using Marfrig.CompraGado.Domain.Entities;
using Marfrig.CompraGado.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Marfrig.CompraGado.Data.Repositories
{
    public class CompraGadoRepository : ICompraGadoRepository
    {
        private readonly MarfrigContext _context;

        public CompraGadoRepository(MarfrigContext context)
        {
            _context = context;
        }

        public void Add(Domain.Entities.CompraGado obj)
        {
            _context.CompraGados.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Domain.Entities.CompraGado> GetAll()
        {
            var _compraGados = _context.CompraGados
                .Include("Pecuarista")
                .Include("CompraGadoItens")
                .Include("CompraGadoItens.Animal")
                .ToList();

            return _compraGados;
        }

        public IEnumerable<Domain.Entities.CompraGado> GetByFilter(FiltroCompraGado filtro)
        {
            var query = _context.CompraGados
                        .Include("Pecuarista")
                        .Include("CompraGadoItens")
                        .Include("CompraGadoItens.Animal")
                        .AsEnumerable();

            if (filtro.PecuaristaId > 0)
                query = query.Where(a => a.PecuaristaId == filtro.PecuaristaId);

            if (filtro.DataDe.HasValue)
                query = query.Where(a => a.DataEntrega >= filtro.DataDe);

            if (filtro.DataAte.HasValue)
                query = query.Where(a => a.DataEntrega <= filtro.DataAte);

            if (filtro.RegistrosPorPagina > 0)
                query = query.Skip((filtro.Pagina - 1) * filtro.RegistrosPorPagina).Take(filtro.RegistrosPorPagina);

            return query.ToList();
        }

        public Domain.Entities.CompraGado GetById(long id)
        {
            return _context.CompraGados
                        .Include("Pecuarista")
                        .Include("CompraGadoItens")
                        .Include("CompraGadoItens.Animal")
                        .Where(a => a.Id == id)
                        .FirstOrDefault();
        }

        public void Remove(Domain.Entities.CompraGado obj)
        {
            _context.CompraGados.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Domain.Entities.CompraGado obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
