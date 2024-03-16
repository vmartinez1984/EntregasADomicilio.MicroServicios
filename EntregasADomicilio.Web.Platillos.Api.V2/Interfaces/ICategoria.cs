using EntregasADomicilio.Web.Platillos.Api.V2.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Platillos.Api.V2.Interfaces
{
    public interface ICategoria
    {
        Task<List<Categoria>> ObtenerTodosAsync();
    }
}
