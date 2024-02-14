using EntregasADomicilio.Admin.Repositorio.Sql.Interfaces;

namespace EntregasADomicilio.Admin.Repositorio.Sql.Entities
{
    public class RepositorySql : IRepositorySql
    {
        

        public RepositorySql(
            ICategoriaRepository categoriaRepository,
            IClienteRepository clienteRepository,
            IDireccionRepository direccionRepository,
            IPlatilloRepository platilloRepository,
            IPedidoRepository pedidoRepository
        )
        {
            Categoria = categoriaRepository;
            Cliente = clienteRepository;
            Direccion = direccionRepository;
            Platillo = platilloRepository;
            Pedido = pedidoRepository;  
        }

        public ICategoriaRepository Categoria { get; }

        public IClienteRepository Cliente { get; }

        public IDireccionRepository Direccion { get; }

        public IPlatilloRepository Platillo { get; }

        public IPedidoRepository Pedido {get; }
    }
}
