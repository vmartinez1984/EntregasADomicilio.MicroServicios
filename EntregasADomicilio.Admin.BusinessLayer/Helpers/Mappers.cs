using AutoMapper;
using EntregasADomicilio.Admin.BusinessLayer.Dtos;
using EntregasADomicilio.Admin.Platillos.Core.Entidades;
using System;

namespace EntregasADomicilio.Admin.BusinessLayer.Helpers
{
    internal class EntregasADomicilioMappers : Profile
    {
        public EntregasADomicilioMappers()
        {
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaDtoIn, Categoria>();
            CreateMap<CategoriaDtoUpdate, Categoria>();

            CreateMap<PlatilloDtoIn, Platillo>()
                .ForMember(platillo => platillo.Id, platilloDto => platilloDto.MapFrom(x=>x.Id.ToString()));
            CreateMap<Platillo, PlatilloDto>();
                //.ForMember(platilloDto => platilloDto.Id);
        }
    }
}
