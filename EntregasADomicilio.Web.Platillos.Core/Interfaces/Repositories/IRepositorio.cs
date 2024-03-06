namespace EntregasADomicilio.Web.Platillos.Core.Interfaces.Repositories
{
    public interface IRepositorio
    {
        public IPlatillo Platillo { get;  }

        public ICategoria Categoria { get;  }
    }
}
