using EntregasADomicilio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregasADomicilio.Core.Interfaces.Web.Pedidos
{
    public interface IPedidoRepositorio
    {
        Task<int> AgregarAsync(Pedido pedido);
        Task<List<Pedido>> ObtenerTodosPorClienteIdAsync(int clienteID);
    }
}
