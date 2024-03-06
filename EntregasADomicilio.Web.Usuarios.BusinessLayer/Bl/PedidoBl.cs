using EntregasADomicilio.Admin.WebData.Core.Dtos.Web;
using EntregasADomilicio.Web.Pedidos.Repositorios.Ws;
using EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Usuarios;

namespace EntregasADomicilio.Web.Usuarios.BusinessLayer.Bl
{
    public class PedidoBl : IPedidoBl
    {
        private readonly PedidoRepositorio pedidoRepositorio;

        public PedidoBl(PedidoRepositorio pedidoRepositorio)
        {
            this.pedidoRepositorio = pedidoRepositorio;
        }

        public async Task<IdDto> AgregarAsync(PedidoDtoIn pedido, int clienteId)
        {      
            IdDto idDto;

            idDto = await pedidoRepositorio.AgregarAsync(pedido, clienteId);

            return idDto;
        }

        //public async  Task<PedidoDto> ObtenerPedidoAsync(int pedidoId)
        //{
        //    PedidoDto pedidoDto;

        //    pedidoDto = null;

        //    return pedidoDto;
        //}

        public async Task<PedidoDto> ObtenerPorIdAsync(int pedidoId)
        {
            PedidoDto pedido;

            pedido = await pedidoRepositorio.ObtnerPorIdAsync(pedidoId);

            return pedido;
        }

        public async Task<List<PedidoDto>> ObtenerTodosPorClienteId(int clienteId)
        {
            List<PedidoDto> pedidos;

            pedidos = await pedidoRepositorio.ObtenerTodosPorClienteIdAsync(clienteId);

            return pedidos;
        }
    }
}
