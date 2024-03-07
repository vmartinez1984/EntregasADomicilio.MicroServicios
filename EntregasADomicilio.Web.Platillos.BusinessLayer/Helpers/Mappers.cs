using AutoMapper;
using EntregasADomicilio.Web.Platillos.BusinessLayer.Dtos;
using EntregasADomicilio.Web.Platillos.Core.Entities;

namespace EntregasADomicilio.Web.Platillos.BusinessLayer.Helpers
{
    internal class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Categoria, CategoriaDto>();

            CreateMap<Platillo, PlatilloDto>()
                .ForMember(platillo => platillo.Categoria, platilloDto => platilloDto.MapFrom(x => x.CategoriaNombre));
        }
    }
}
