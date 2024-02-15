using AutoMapper;
using EntregasADomicilio.Admin.WebData.Core.Dtos.Web;
using EntregasADomicilio.Admin.WebData.Core.Entities;

namespace EntregasADomicilio.Web.Usuarios.BusinessLayer.Helpers
{
    internal class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<ClienteDtoIn, Cliente>();
            CreateMap<DireccionDtoIn, Direccion>();

            CreateMap<Cliente, ClienteDto>();
        }
    }
}
