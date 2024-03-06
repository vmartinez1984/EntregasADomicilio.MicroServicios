using EntregasADomicilio.Web.Usuarios.Core.Entitites;
using EntregasADomicilio.Web.Usuarios.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregasADomiclio.AdminDeUsuario.Sql.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UsuarioRepositorio(
            //SignInManager<IdentityUser> signInManager,
            //UserManager<IdentityUser> userManager
        )
        {
            //_userManager = userManager;
            //_signInManager = signInManager;
        }

        public Task AgregarRoleASync(string guid, string role)
        {
            throw new NotImplementedException();
        }

        public Task<string> AgregarUsuarioAsync(UsuarioEntity usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioEntity> ObtenerUsuarioAsync(string correo, string contrasenia)
        {
            UsuarioEntity usuarioEntity;
            var resultado = await _signInManager.PasswordSignInAsync(correo, contrasenia, isPersistent: false, lockoutOnFailure: false);

            usuarioEntity = null;
            if (resultado.Succeeded)
            {
                IdentityUser usuario;

                usuario = await _userManager.FindByEmailAsync(correo);
                usuarioEntity = new UsuarioEntity
                {
                    Correo = "",
                    EstaActivo = true,
                    Id = "",
                    Nombre = "",
                    Roles = new List<Role>()
                };
            }

            return usuarioEntity;
        }
    }
}
