using EntregasADomicilio.Web.Platillos.Core.Entities;
using EntregasADomicilio.Web.Platillos.Core.Interfaces.Repositories;
using EntregasADomicilio.Web.Platillos.Repositorios.Sql.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Platillos.Repositorios.Sql.Repository
{
    public class PlatilloRepositorio : IPlatillo
    {
        private readonly AppDbContext _appDbContext;

        public PlatilloRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Platillo>> ObtenerTodosAsync()
        {
            return
            await _appDbContext.Platillo
                    .Include(x => x.Categoria)
                    .Where(x => x.EstaActivo).ToListAsync();
        }
    }
}
