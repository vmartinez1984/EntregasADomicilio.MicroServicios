using EntregasADomicilio.Usuarios.Core.Entities;

namespace EntregasADomicilio.Usuarios.Core.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<string> AgregarAsync(Usuario usuario);
        Task<Usuario> ObtenerPorInicioDeSesionId(string id);
    }
}
