using Marfrig.CompraGado.Application.Interfaces;
using Marfrig.CompraGado.Domain.Entities;
using Marfrig.CompraGado.Domain.Interfaces.Services;

namespace Marfrig.CompraGado.Application.Application
{
    public class AnimalApplication : ApplicationBase<Animal>, IAnimalApplication
    {
        private readonly IAnimalService _animalService;

        public AnimalApplication(IAnimalService animalService)
            : base(animalService)
        {
            _animalService = animalService;
        }
    }
}
