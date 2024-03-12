namespace EntregasADomicilio.Usuarios.BusinessLayer.Bl
{
    public class UnitOfWork
    {
        public UnitOfWork(ClienteBl clienteBl)
        {
                Cliente = clienteBl;
        }

        public ClienteBl Cliente { get; set; }
    }
}
