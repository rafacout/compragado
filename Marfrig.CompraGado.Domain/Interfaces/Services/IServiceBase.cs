using System.Collections.Generic;

namespace Marfrig.CompraGado.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : class
    {
        void Add(T obj);

        void Update(T obj);

        T GetById(int id);

        IEnumerable<T> GetAll();

        void Remove(T obj);
    }
}
