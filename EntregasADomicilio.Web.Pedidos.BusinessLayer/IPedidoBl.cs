using EntregasADomicilio.Web.Pedidos.Core.Dtos;

namespace EntregasADomicilio.Web.Pedidos.BusinessLayer
{
    public interface IPedidoBl
    {
        Task<string> AgregarAsync(PedidoDtoIn pedido, string clienteId);
        Task<PedidoDto> ObtenerAsync(string pedidoId);
        Task<List<PedidoDto>> ObtenerTodosPorClienteIdAsync(string clienteId);
    }
}