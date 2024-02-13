using AutoMapper;
using EntregasADomicilio.Web.Platillos.Dtos;
using EntregasADomicilio.Web.Repositorios.Sql.Entities;

namespace EntregasADomicilio.Web.Platillos.Helpers
{
    public class Mappers: Profile
    {
        public Mappers()
        {
            CreateMap<Categoria, CategoriaDto>();

            CreateMap<Platillo, PlatilloDto>();
        }
    }
}
