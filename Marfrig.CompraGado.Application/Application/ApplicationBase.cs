using Marfrig.CompraGado.Application.Interfaces;
using Marfrig.CompraGado.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Marfrig.CompraGado.Application.Application
{
    public class ApplicationBase<T> : IApplicationBase<T> where T : class
    {
        private readonly IServiceBase<T> _serviceBase;

        public ApplicationBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(T obj)
        {
            _serviceBase.Add(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public T GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public void Remove(T obj)
        {
            _serviceBase.Remove(obj);
        }

        public void Update(T obj)
        {
            _serviceBase.Update(obj);
        }
    }
}
