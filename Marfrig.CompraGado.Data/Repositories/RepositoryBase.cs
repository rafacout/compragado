using Marfrig.CompraGado.Data.Context;
using Marfrig.CompraGado.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marfrig.CompraGado.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly MarfrigContext _context;

        public RepositoryBase(MarfrigContext context)
        {
            _context = context;
        }

        public virtual void Add(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Remove(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public virtual void Update(T obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
