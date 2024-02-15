using EntregasADomicilio.Admin.WebData.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Usuarios
{
    public interface IRepositorio
    {
        public IClienteRepositorio Cliente { get; }

        public IDireccionRepositorio Direccion { get; }
    }

    public interface IDireccionRepositorio
    {
        Task<int> AgregarAsync(Direccion direccion);

        Task Actualizar(Direccion direccion);
        Task<Direccion> ObtenerPorId(int direccionId);
        Task<List<Direccion>> ObtenerTodosPorClienteIdAsync(int clienteId);
    }

    public interface IClienteRepositorio
    {
        Task<int> AgregarAsync(Cliente cliente);
        Task<Cliente> ObtenerPorIdAsync(int clienteId);
        Task<Cliente> ObtenerPorUsuarioId(string id);
    }
}
