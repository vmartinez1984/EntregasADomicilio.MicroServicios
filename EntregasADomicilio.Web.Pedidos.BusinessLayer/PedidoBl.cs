using AutoMapper;
using EntregasADomicilio.Admin.WebData.Core.Dtos.Web;
using EntregasADomicilio.Core.Entities;

namespace EntregasADomicilio.Web.Pedidos.BusinessLayer
{
    public class PedidoBl : IPedidoBl
    {
        public readonly IRepositorySql _repositorySql;
        public readonly IMapper _mapper;

        public PedidoBl(IRepositorySql repositorySql, IMapper mapper)
        {
            this._repositorySql = repositorySql;
            this._mapper = mapper;
        }    

        public async Task<int> AgregarAsync(PedidoDtoIn pedidoDto, int clienteId)
        {
            Pedido pedido;

            pedido = _mapper.Map<Pedido>(pedidoDto);
            pedido.ClienteId = clienteId;
            pedido.Estatus = EstatusDelPedido.PedidoRealizado;
            pedido.Total = pedido.ListaDetalleDelPedido.Sum(x => x.Precio);
            await _repositorySql.Pedido.AgregarAsync(pedido);

            return pedido.Id;
        }

        public async Task<List<PedidoDto>> ObtenerTodosPorClienteId(int clienteID)
        {
            List<PedidoDto> pedidosDtos;
            List<Pedido> pedidos;

            pedidos = await _repositorySql.Pedido.ObtenerTodosPorClienteIdAsync(clienteID);
            pedidosDtos = _mapper.Map<List<PedidoDto>>(pedidos);

            return pedidosDtos;
        }
    }
}
