using EntregasADomicilio.Admin.WebData.Core.Entities;
using EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Usuarios;
using EntregasADomicilio.Web.Usuarios.Repositorio.Sql.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EntregasADomicilio.Web.Usuarios.Repositorio.Sql.Repositorios
{
    public class DireccionRepositorio: IDireccionRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public DireccionRepositorio(AppDbContext appDbContext)
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
            return await _appDbContext.Direccion.Where(x => x.Id == direccionId).FirstOrDefaultAsync();
        }

        public async Task<List<Direccion>> ObtenerTodosPorClienteIdAsync(int clienteId)
        {
            return await _appDbContext.Direccion.Where(x => x.UsuarioId == clienteId).ToListAsync();
        }
    }
}
