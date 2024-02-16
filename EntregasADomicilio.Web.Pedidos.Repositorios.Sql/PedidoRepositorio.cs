using EntregasADomicilio.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntregasADomicilio.Web.Pedidos.Repositorios.Sql
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public PedidoRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> AgregarAsync(Pedido pedido)
        {
            _appDbContext.Pedido.Add(pedido);
            await _appDbContext.SaveChangesAsync();

            return pedido.Id;
        }

        public async Task<Pedido> ObtenerPorIdAsync(int pedidoId)
        {
            return await _appDbContext.Pedido
                .Include(x => x.ListaDetalleDelPedido)
                    .ThenInclude(x => x.Platillo)
                    .ThenInclude(x => x.Categoria)
                .FirstAsync(x=> x.Id == pedidoId);
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