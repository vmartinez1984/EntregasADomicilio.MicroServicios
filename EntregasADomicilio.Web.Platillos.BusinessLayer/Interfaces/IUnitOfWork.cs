namespace EntregasADomicilio.Web.Platillos.BusinessLayer.Interfaces
{
    public interface IUnitOfWorkBl
    {
        public ICategoriaBl Categoria { get;  }

        public IPlatilloBl Platillo { get;  }
    }
}
