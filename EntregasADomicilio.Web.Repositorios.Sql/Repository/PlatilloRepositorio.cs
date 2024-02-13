using EntregasADomicilio.Web.Repositorios.Sql.Contexts;
using EntregasADomicilio.Web.Repositorios.Sql.Entities;
using EntregasADomicilio.Web.Repositorios.Sql.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Repositorios.Sql.Repository
{
    public class PlatilloRepositorio : IPlatillo
    {
        private readonly AppDbContext _appDbContext;

        public PlatilloRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Platillo>> ObtenerTodos()
        {
            return
            await _appDbContext.Platillo
                    .Include(x => x.Categoria)
                    .Where(x => x.EstaActivo).ToListAsync();
        }
    }
}
