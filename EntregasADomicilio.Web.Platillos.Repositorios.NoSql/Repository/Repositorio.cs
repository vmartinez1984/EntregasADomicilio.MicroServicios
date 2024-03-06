using EntregasADomicilio.Web.Platillos.Core.Interfaces.Repositories;

namespace EntregasADomicilio.Web.Platillos.Repositorios.NoSql.Repository
{
    public class Repositorio : IRepositorio
    {
        public Repositorio(IPlatillo platillo, ICategoria categoria)
        {
            Platillo = platillo;
            Categoria = categoria;
        }

        public IPlatillo Platillo { get; set; }
        public ICategoria Categoria { get; set; }
    }
}
