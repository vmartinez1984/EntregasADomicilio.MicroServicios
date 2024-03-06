using EntregasADomicilio.Web.Usuarios.Core.Entitites;
using EntregasADomicilio.Web.Usuarios.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasADomicilio.AdminDeUsuario.NoSql
{
    public class UsuarioRepositorioNoSql : IUsuarioRepositorio
    {
        public Task AgregarRoleASync(string guid, string role)
        {
            throw new NotImplementedException();
        }

        public Task<string> AgregarUsuarioAsync(UsuarioEntity usuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntity> ObtenerUsuarioAsync(string correo, string contrasenia)
        {
            UsuarioEntity usuario = new UsuarioEntity
            {
                Correo = "ahal_tocob@hotmail.com",
                EstaActivo = true,
                Id = Guid.NewGuid().ToString(),
                Nombre = "Víctor Mtz",
                Roles = new List<Role> { new Role { Id = Guid.NewGuid().ToString(), Nombre = "Cliente", EstaActivo = true } }
            };

            return Task.FromResult(usuario);
        }
    }
}
