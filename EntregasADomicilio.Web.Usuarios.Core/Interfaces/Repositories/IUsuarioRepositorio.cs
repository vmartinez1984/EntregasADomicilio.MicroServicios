using EntregasADomicilio.Web.Usuarios.Core.Entitites;

namespace EntregasADomicilio.Web.Usuarios.Core.Interfaces.Repositories
{
    public interface IUsuarioRepositorio
    {
        //public Task<bool> EsValido(string correo, string contrasenia);

        //public Task<string> ObtenerId(string correo);

        public Task<UsuarioEntity> ObtenerUsuarioAsync(string correo,string contrasenia);

        public Task<string> AgregarUsuarioAsync(UsuarioEntity usuario);

        //public Task ActualizarUsuarioAsync(string id, Usuario usuario);

        public Task AgregarRoleASync(string guid, string role);
    }
}
