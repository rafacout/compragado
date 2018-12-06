using Marfrig.CompraGado.API.ViewModels;
using Marfrig.CompraGado.Domain.Entities;

namespace Marfrig.CompraGado.API.AutoMapperConfig
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Animal, AnimalViewModel>();
            CreateMap<Pecuarista, PecuaristaViewModel>();
        }
    }
}