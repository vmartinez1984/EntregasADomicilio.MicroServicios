using EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Usuarios;

namespace EntregasADomicilio.Web.Usuarios.Repositorio.Sql.Repositorios
{
    public class RepositorioU : IRepositorio
    {
        public RepositorioU(IClienteRepositorio clienteRepositorio, IDireccionRepositorio direccionRepositorio)
        {
            Cliente = clienteRepositorio;
            Direccion = direccionRepositorio;
        }

        public IClienteRepositorio Cliente { get; }
        public IDireccionRepositorio Direccion { get; }

    }
}
