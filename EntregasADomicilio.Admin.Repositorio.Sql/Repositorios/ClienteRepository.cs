using EntregasADomicilio.Admin.Repositorio.Sql.Contexts;
using EntregasADomicilio.Admin.Repositorio.Sql.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.Repositorio.Sql.Entities
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClienteRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task ActualizarAsync(Cliente entity)
        {
            _appDbContext.Cliente.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> AgregarAsync(Cliente cliente)
        {
            _appDbContext.Cliente.Add(cliente);
            await _appDbContext.SaveChangesAsync();

            return cliente.Id;
        }

        public async Task<Cliente> ObtenerPorIdAsync(int clienteId)
        {
            return await _appDbContext.Cliente
                .Include(x=>x.Direcciones)
                .Where(x => x.Id == clienteId)
                .FirstOrDefaultAsync();
        }

        public async Task<Cliente> ObtenerPorUsuarioId(string usuarioId)
        {
            return await _appDbContext.Cliente.Where(x=> x.UsuarioId == usuarioId).FirstOrDefaultAsync();
        }
    }
}
