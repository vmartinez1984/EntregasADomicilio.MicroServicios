using EntregasADomicilio.Core.Entities;

namespace EntregasADomicilio.Web.Pedidos.Repositorios.Sql
{
    public interface IPedidoRepositorio
    {
        Task<int> AgregarAsync(Pedido pedido);
        Task<Pedido> ObtenerPorIdAsync(int pedidoId);
        Task<List<Pedido>> ObtenerTodosPorClienteIdAsync(int clienteID);
    }
}