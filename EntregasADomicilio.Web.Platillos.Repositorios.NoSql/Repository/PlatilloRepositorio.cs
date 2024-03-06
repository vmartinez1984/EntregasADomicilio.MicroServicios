using EntregasADomicilio.Web.Platillos.Core.Entities;
using EntregasADomicilio.Web.Platillos.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Platillos.Repositorios.NoSql.Repository
{
    public class PlatilloRepositorio : IPlatillo
    {


        public PlatilloRepositorio()
        {

        }

        public async Task<List<Platillo>> ObtenerTodosAsync()
        {
            return
             new List<Platillo>();
        }
    }
}
