using EntregasADomicilio.Admin.Repositorio.Sql.Contexts;
using EntregasADomicilio.Admin.Repositorio.Sql.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.Repositorio.Sql.Entities
{
    public class PlatilloRepository : IPlatilloRepository
    {
        private readonly AppDbContext _appDbContext;

        public PlatilloRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task ActualizarAsync(Platillo platillo)
        {
            _appDbContext.Platillo.Update(platillo);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> AgregarAsync(Platillo platillo)
        {
            _appDbContext.Platillo.Add(platillo);
            await _appDbContext.SaveChangesAsync();

            return platillo.Id;
        }

        public async Task<Platillo> ObtenerPorIdAsync(int platilloId)
        {
            return await _appDbContext.Platillo
                .Include(x => x.ListaDeArchivos)
                .Include(x => x.Categoria)
                .Where(x => x.Id == platilloId).FirstOrDefaultAsync();
        }

        public async Task<List<Platillo>> ObtenerTodosAsync(bool? isActive = null)
        {
            if (isActive == null)
                return await _appDbContext.Platillo
                    .Include(x => x.Categoria)
                    .ToListAsync();
            else
                return await _appDbContext.Platillo
                    .Include(x => x.Categoria)
                    .Where(x => x.EstaActivo == isActive).ToListAsync();
        }
    }
}
