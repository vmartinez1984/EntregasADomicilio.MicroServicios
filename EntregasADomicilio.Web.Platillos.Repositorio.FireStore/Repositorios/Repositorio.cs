using EntregasADomicilio.Web.Platillos.Core.Interfaces.Repositories;

namespace EntregasADomicilio.Web.Platillos.Repositorios.FireStore.Repositorios
{
    public class Repositorio : IRepositorio
    {
        public Repositorio(
            IPlatillo platillo,
            ICategoria categoria
        )
        {
            Platillo = platillo;
            Categoria = categoria;
        }

        public IPlatillo Platillo { get; }

        public ICategoria Categoria { get; }
    }
}