using EntregasADomicilio.Admin.WebData.Core.Entities;
using EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Usuarios;
using EntregasADomicilio.Web.Usuarios.Repositorio.Sql.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EntregasADomicilio.Web.Usuarios.Repositorio.Sql.Repositorios
{
    public class ClienteRepositorio: IClienteRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public ClienteRepositorio(AppDbContext appDbContext)
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
                .Include(x => x.Direcciones)
                .Where(x => x.Id == clienteId)
                .FirstOrDefaultAsync();
        }

        public async Task<Cliente> ObtenerPorUsuarioId(string usuarioId)
        {
            return await _appDbContext.Cliente.Where(x => x.UsuarioId == usuarioId).FirstOrDefaultAsync();
        }
    }
}
