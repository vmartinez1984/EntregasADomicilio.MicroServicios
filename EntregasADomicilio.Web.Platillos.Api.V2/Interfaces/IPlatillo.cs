using EntregasADomicilio.Web.Platillos.Api.V2.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Platillos.Api.V2.Interfaces
{
    public interface IPlatillo
    {
        Task<Platillo> ObtenerPorIdAsync(string id);
        Task<List<Platillo>> ObtenerTodosAsync();
    }
}
