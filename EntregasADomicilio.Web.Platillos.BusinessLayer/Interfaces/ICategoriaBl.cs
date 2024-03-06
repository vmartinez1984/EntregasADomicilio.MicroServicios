using System.Collections.Generic;
using System.Threading.Tasks;
using EntregasADomicilio.Web.Platillos.BusinessLayer.Dtos;

namespace EntregasADomicilio.Web.Platillos.BusinessLayer.Interfaces
{
    public interface ICategoriaBl
    {
        Task<List<CategoriaDto>> ObtenerTodos();
    }
}
