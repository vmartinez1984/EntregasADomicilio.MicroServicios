using EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Usuarios;

namespace EntregasADomicilio.Web.Usuarios.BusinessLayer.Bl
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IUsuarioBl usuarioBl,
            IClienteBl clienteBl
        )
        {
            Usuario = usuarioBl;    
            Cliente = clienteBl;
        }

        public IUsuarioBl Usuario { get; set; }
        public IClienteBl Cliente { get; set; }
    }
}
