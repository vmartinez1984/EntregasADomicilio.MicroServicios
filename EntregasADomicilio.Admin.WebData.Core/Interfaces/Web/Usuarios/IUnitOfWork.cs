using EntregasADomicilio.Admin.WebData.Core.Dtos.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Usuarios
{
    public interface IUnitOfWork
    {
        public IUsuarioBl Usuario { get;  }

        public IClienteBl Cliente { get;  }

        public IPedidoBl Pedido { get;  }
    }

    public interface IUsuarioBl
    {
        Task<string> AgregarAsync(UsuarioDtoIn usuarioDtoIn);
        Task<TokenDto> LoginAsync(LoginDto login);
    }

    public interface IClienteBl
    {
        Task<int> AgregarAsync(ClienteDtoIn cliente);

        Task<ClienteDto> ObtenerPorIdAsync(int clienteId);

        Task<int> AgregarDireccionAsync(int clienteId, DireccionDtoIn direccion);

        Task ActualizarDireccionAsync(int direccionId, DireccionDtoIn direccion);

        Task ColocarComoPrincipalAsync(int direccionId, int clienteId);

        //Task ActualizarAsync(int clienteId, ClienteVentaDtoUpdate cliente);
    }

    public interface IPedidoBl
    {
        Task<IdDto> AgregarAsync(PedidoDtoIn pedido, int clienteId);
        Task<PedidoDto> ObtenerPorIdAsync(int pedidoId);
        Task<List<PedidoDto>> ObtenerTodosPorClienteId(int v);
    }
}
