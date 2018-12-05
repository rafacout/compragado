﻿using System.Collections.Generic;

namespace Marfrig.CompraGado.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T obj);

        T GetById(long id);

        IEnumerable<T> GetAll();

        void Update(T obj);

        void Remove(T obj);
    }
}
