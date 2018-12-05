using System.Collections.Generic;

namespace Marfrig.CompraGado.Application.Interfaces
{
    public interface IApplicationBase<T> where T : class
    {
        void Add(T obj);

        T GetById(int id);

        IEnumerable<T> GetAll();

        void Update(T obj);

        void Remove(T obj);
    }
}
