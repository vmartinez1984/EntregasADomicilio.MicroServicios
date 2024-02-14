using EntregasADomicilio.Admin.Repositorio.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.Repositorio.Sql.Interfaces
{
    public interface IRepositorySql
    {
        public ICategoriaRepository Categoria { get; }

        public IClienteRepository Cliente { get; }

        public IDireccionRepository Direccion { get; }

        public IPlatilloRepository Platillo { get; }

        public IPedidoRepository Pedido { get; }
    }

    public interface IPedidoRepository
    {
        Task<int> AgregarAsync(Pedido pedido);
        Task<List<Pedido>> ObtenerTodosPorClienteIdAsync(int clienteID);
    }

    public interface IDireccionRepository
    {
        Task<int> AgregarAsync(Direccion direccion);

        Task Actualizar(Direccion direccion);
        Task<Direccion> ObtenerPorId(int direccionId);
        Task<List<Direccion>> ObtenerTodosPorClienteIdAsync(int clienteId);
    }

    public interface ICategoriaRepository
    {
        Task<List<Categoria>> ObtenerTodos(bool? estaActivo = null);

        Task<int> Agregar(Categoria categoria);

        Task Actualizar(Categoria categoria);

        Task Borrar(int categoriaId);

        Task<Categoria> ObtenerPorIdAsync(int categoriaId);
        Task<Categoria> ObtenerPorGuidAsync(Guid guid);
    }

    public interface IClienteRepository
    {
        Task ActualizarAsync(Cliente entity);
        Task<int> AgregarAsync(Cliente cliente);
        Task<Cliente> ObtenerPorIdAsync(int clienteId);
        Task<Cliente> ObtenerPorUsuarioId(string usuarioId);
    }

    public interface IPlatilloRepository
    {
        Task ActualizarAsync(Platillo platillo);
        Task<int> AgregarAsync(Platillo platillo);
        Task<Platillo> ObtenerPorIdAsync(int platilloId);
        Task<List<Platillo>> ObtenerTodosAsync(bool? isActive = null);
    }
}
