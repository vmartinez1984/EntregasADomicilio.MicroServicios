using EntregasADomicilio.Web.Repositorios.Sql.Interfaces;

namespace EntregasADomicilio.Web.Repositorios.Sql.Repository
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
