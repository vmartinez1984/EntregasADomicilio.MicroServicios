using AutoMapper;
using EntregasADomicilio.Admin.BusinessLayer.Dtos;
using EntregasADomicilio.Admin.Repositorio.Sql.Entities;

namespace EntregasADomicilio.Admin.BusinessLayer.Helpers
{
    internal class EntregasADomicilioMappers : Profile
    {
        public EntregasADomicilioMappers()
        {
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaDtoIn, Categoria>();

            //CreateMap<ClienteDtoIn, Cliente>();
            //CreateMap<DireccionDtoIn, Direccion>();
            //CreateMap<ClienteDtoUpdate, Cliente>();
            //CreateMap<Cliente, ClienteDto>();
            //CreateMap<Direccion, DireccionDto>();

            CreateMap<PlatilloDtoIn, Platillo>();
            CreateMap<Platillo, PlatilloDto>();
        }
    }
}
