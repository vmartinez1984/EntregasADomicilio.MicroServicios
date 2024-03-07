using EntregasADomicilio.Admin.Platillos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.Platillos.Core.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> ObtenerTodosAsync();

        Task<string> AgregarAsync(Categoria categoria);

        Task Actualizar(Categoria categoria);
        Task<Categoria> ObtenerPorIdAsync(string id);
        Task<bool> ExisteAsync(string categoria);
    }

    public interface IRepositorio
    {
        public ICategoriaRepositorio Categoria { get;  }
        public IPlatilloRepositorio Platillo { get; }
    }

    public interface IPlatilloRepositorio
    {
        Task ActualizarAsync(Platillo platilloEntity);
        Task<string> AgregarAsync(Platillo entity);
        Task<Platillo> ObtenerPorIdAsync(string platilloId);
        Task<List<Platillo>> ObtenerTodosAsync(bool? estaActivo = null);
    }
}