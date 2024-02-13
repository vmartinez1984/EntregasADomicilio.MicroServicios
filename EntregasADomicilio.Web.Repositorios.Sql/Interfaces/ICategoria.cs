using EntregasADomicilio.Web.Repositorios.Sql.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Repositorios.Sql.Interfaces
{
    public interface ICategoria
    {
        Task<IEnumerable<Categoria>> ObtenerTodos(); 
    }
}
