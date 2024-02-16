using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Pedidos.BusinessLayer
{
    public interface IPedidoBl
    {
        Task<int> AgregarAsync(PedidoDtoIn pedido, int clienteId);
        Task<PedidoDto> ObtenerAsync(int pedidoId);
        Task<List<PedidoDto>> ObtenerTodosPorClienteIdAsync(int clienteId);
    }
}