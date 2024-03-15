using AutoMapper;
using EntregasADomicilio.Web.Pedidos.Core.Dtos;
using EntregasADomicilio.Web.Pedidos.Core.Entidades;

namespace EntregasADomicilio.Web.Pedidos.BusinessLayer
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<PlatilloDtoIn, Platillo>();
            CreateMap<Platillo, PlatilloDto>();           
            CreateMap<Pedido,PedidoDto>();
            //CreateMap<DetalleDelPedido, PlatilloDto>()
            //    .ForMember(x => x.Id, y => y.MapFrom(x => x.Platillo.Id))
            //    .ForMember(x => x.Nombre, y => y.MapFrom(x => x.Platillo.Nombre))
            //    .ForMember(x => x.Descripcion, y => y.MapFrom(x => x.Platillo.Descripcion))
            //    //.ForMember(x => x.Categoria, y => y.MapFrom(x => x.Platillo.Categoria))
            //    .ForMember(x => x.Precio, y => y.MapFrom(y => y.Precio));
        }
    }
}
