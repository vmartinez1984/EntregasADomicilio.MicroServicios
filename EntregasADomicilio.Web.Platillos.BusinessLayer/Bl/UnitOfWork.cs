using EntregasADomicilio.Web.Platillos.BusinessLayer.Interfaces;

namespace EntregasADomicilio.Web.Platillos.BusinessLayer.Bl
{
    public class UnitOfWork : IUnitOfWorkBl
    {
        public UnitOfWork(IPlatilloBl platilloBl, ICategoriaBl categoriaBl)
        {
            Categoria = categoriaBl;
             
            Platillo = platilloBl;
        }

        public IPlatilloBl Platillo { get; }

        public ICategoriaBl Categoria { get; }        
    }
}
