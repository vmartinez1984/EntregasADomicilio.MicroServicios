using EntregasADomicilio.Web.Pedidos.Core.Entidades;

namespace EntregasADomicilio.Web.Pedidos.Core.Interfaces
{
    public interface IPedidoRepositorio
    {
        Task<string> AgregarAsync(Pedido pedido);
        Task<Pedido> ObtenerPorIdAsync(string pedidoId);
        Task<List<Pedido>> ObtenerTodosPorClienteIdAsync(string clienteID);
    }
}