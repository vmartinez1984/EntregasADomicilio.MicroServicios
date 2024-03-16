using EntregasADomicilio.Web.Platillos.Api.V2.Interfaces;

namespace EntregasADomicilio.Web.Platillos.Api.V2.Repositorios
{
    public class Repositorio : IRepositorio
    {
        public Repositorio(
            IPlatillo platillo,
            ICategoria categoria,
            ITienda tienda
        )
        {
            Platillo = platillo;
            Categoria = categoria;
            Tienda = tienda;
        }

        public IPlatillo Platillo { get; }

        public ICategoria Categoria { get; }
        public ITienda Tienda { get; }
    }
}