

namespace EntregasADomicilio.Admin.BusinessLayer.Bl
{
    public class UnitOfWorkBl
    {
        public UnitOfWorkBl(
           CategoriaBl categoriaBl,
           //IUsuarioBl usuarioBl,
           //IClienteBl clienteBl,
           PlatilloBl platilloBl
       )
        {
            Categoria = categoriaBl;
            //Usuario = usuarioBl;
            //Cliente = clienteBl;
            Platillo = platilloBl;
        }

        public CategoriaBl Categoria { get; }

        //public IUsuarioBl Usuario { get; }

        //public IClienteBl Cliente { get; }

        public PlatilloBl Platillo { get; }
    }
}
