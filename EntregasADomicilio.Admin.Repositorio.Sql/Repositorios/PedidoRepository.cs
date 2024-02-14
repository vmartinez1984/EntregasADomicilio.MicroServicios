using EntregasADomicilio.Admin.Repositorio.Sql.Contexts;
using EntregasADomicilio.Admin.Repositorio.Sql.Interfaces;
using EntregasADomicilio.Admin.Repositorio.Sql.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.Repositorio.Sql.Entities
{
    public class PedidoRepository : BaseRepository, IPedidoRepository
    {
        public PedidoRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<int> AgregarAsync(Pedido pedido)
        {
            _appDbContext.Pedido.Add(pedido);
            await _appDbContext.SaveChangesAsync();

            return pedido.Id;
        }

        public async Task<List<Pedido>> ObtenerTodosPorClienteIdAsync(int clienteID)
        {
            List<Pedido> lista;

            lista = await _appDbContext.Pedido
                .Include(x => x.ListaDetalleDelPedido)
                    .ThenInclude(x => x.Platillo)
                    .ThenInclude(x => x.Categoria)
                .Where(x => x.ClienteId == clienteID).OrderByDescending(x => x.FechaDeRegistro).ToListAsync();

            return lista;
        }
    }
}
