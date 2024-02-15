using EntregasADomicilio.Admin.WebData.Core.Dtos.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregasADomicilio.Core.Interfaces.Web.Pedidos
{
    public interface IPedidoBl
    {
        Task<int> AgregarAsync(PedidoDtoIn pedido, int clienteId);
        Task<List<PedidoDto>> ObtenerTodosPorClienteId(int clienteID);
    }
}
