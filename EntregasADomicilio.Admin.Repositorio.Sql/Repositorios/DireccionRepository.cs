using EntregasADomicilio.Admin.Repositorio.Sql.Contexts;
using EntregasADomicilio.Admin.Repositorio.Sql.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.Repositorio.Sql.Entities
{
    public class DireccionRepository : IDireccionRepository
    {
        private readonly AppDbContext _appDbContext;

        public DireccionRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task Actualizar(Direccion direccion)
        {
            _appDbContext.Direccion.Update(direccion);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> AgregarAsync(Direccion direccion)
        {
            await _appDbContext.Direccion.AddAsync(direccion);
            await _appDbContext.SaveChangesAsync();
            
            return direccion.Id;
        }

        public async Task<Direccion> ObtenerPorId(int direccionId)
        {
            return await _appDbContext.Direccion.Where(x=> x.Id == direccionId).FirstOrDefaultAsync();   
        }

        public async Task<List<Direccion>> ObtenerTodosPorClienteIdAsync(int clienteId)
        {
            return await _appDbContext.Direccion.Where(x=> x.UsuarioId == clienteId).ToListAsync();
        }
    }
}
