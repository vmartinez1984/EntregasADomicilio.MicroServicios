using EntregasADomicilio.Admin.WebData.Core.Dtos.Web;
using EntregasADomicilio.Admin.WebData.Core.Entities;
using EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Usuarios;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EntregasADomicilio.Web.Usuarios.BusinessLayer.Bl
{
    public class UsuarioBl: IUsuarioBl
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IRepositorio _repositorySql;

        public UsuarioBl(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration,
            IRepositorio repositorySql
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _repositorySql = repositorySql;
        }



        public async Task<TokenDto> LoginAsync(LoginDto login)
        {
            var resultado = await _signInManager.PasswordSignInAsync(login.Correo, login.Contrasenia, isPersistent: false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                var usuario = await _userManager.FindByEmailAsync(login.Correo);
                Cliente cliente;

                cliente = await _repositorySql.Cliente.ObtenerPorUsuarioId(usuario.Id);
                if (cliente == null)
                    return null;

                return await ObtenerToken(login);
            }
            else
            {
                return null;
            }
        }

        private async Task<TokenDto> ObtenerToken(LoginDto credenciales)
        {

            var claims = new List<Claim>()
            {
                    new Claim("email", credenciales.Correo)
            };

            var usuario = await _userManager.FindByEmailAsync(credenciales.Correo);
            Cliente cliente;

            cliente = await _repositorySql.Cliente.ObtenerPorUsuarioId(usuario.Id);
            var claimsDb = await _userManager.GetClaimsAsync(usuario);
            claims.AddRange(await ObtenerClaimsDeUsuarioAsync(usuario));
            claims.AddRange(claimsDb);

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["LLaveJwt"]));
            var credential = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
            var expiracion = DateTime.UtcNow.AddDays(1);
            var token = new JwtSecurityToken(
                //issuer: null, 
                //audience: null, 
                claims: claims, 
                expires: expiracion, 
                signingCredentials: credential
            );

            return new TokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracion = expiracion,
            };
        }

        private async Task<IEnumerable<Claim>> ObtenerClaimsDeUsuarioAsync(IdentityUser usuario)
        {
            Cliente cliente;

            cliente = await _repositorySql.Cliente.ObtenerPorUsuarioId(usuario.Id);

            var claims = new List<Claim>
            {
                    new Claim("Nombre", $"{cliente.Nombre} {cliente.Apellidos}"),
                    new Claim("ClienteId", cliente.Id.ToString())
            };

            return claims;
        }

        public async Task<string> AgregarAsync(UsuarioDtoIn usuario)
        {
            IdentityUser identityUser;

            identityUser = new IdentityUser
            {
                UserName = usuario.Correo,
                Email = usuario.Correo
            };
            var resultado = await _userManager.CreateAsync(identityUser, usuario.Contrasenia);
            await _userManager.AddClaimAsync(identityUser, new Claim("Role", usuario.Role));
            if (!resultado.Succeeded)
            {
                throw new Exception();
            }

            return identityUser.Id;
        }
    }
}
