using Marfrig.CompraGado.Domain.Entities;
using Marfrig.CompraGado.Domain.Interfaces.Repositories;
using Marfrig.CompraGado.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Marfrig.CompraGado.Domain.Services
{
    public class CompraGadoService : ICompraGadoService
    {
        private readonly ICompraGadoRepository _animalRepository;

        public CompraGadoService(ICompraGadoRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public void Add(Entities.CompraGado obj)
        {
            _animalRepository.Add(obj);
        }

        public void Update(Entities.CompraGado obj)
        {
            _animalRepository.Update(obj);
        }

        public IEnumerable<Entities.CompraGado> GetAll()
        {
            return _animalRepository.GetAll();
        }

        public Entities.CompraGado GetById(int id)
        {
            return _animalRepository.GetById(id);
        }

        public void Remove(Entities.CompraGado obj)
        {
            _animalRepository.Remove(obj);
        }

        public IEnumerable<Entities.CompraGado> GetByFilter(FiltroCompraGado filtro)
        {
            return _animalRepository.GetByFilter(filtro);
        }
    }
}
