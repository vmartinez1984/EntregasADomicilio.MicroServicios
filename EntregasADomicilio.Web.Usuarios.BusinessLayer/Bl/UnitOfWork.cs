using EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Usuarios;

namespace EntregasADomicilio.Web.Usuarios.BusinessLayer.Bl
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IUsuarioBl usuarioBl,
            IClienteBl clienteBl,
            IPedidoBl pedidoBl
        )
        {
            Usuario = usuarioBl;
            Cliente = clienteBl;
            Pedido = pedidoBl;
        }

        public IUsuarioBl Usuario { get; }
        public IClienteBl Cliente { get; }
        public IPedidoBl Pedido { get; }
    }
}
