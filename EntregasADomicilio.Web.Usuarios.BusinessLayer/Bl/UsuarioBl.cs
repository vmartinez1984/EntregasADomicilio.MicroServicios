using EntregasADomicilio.Admin.WebData.Core.Dtos.Web;
using EntregasADomicilio.Admin.WebData.Core.Entities;
using EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Usuarios;
//using EntregasADomicilio.Web.Usuarios.Core.Entitites;
//using EntregasADomicilio.Web.Usuarios.Core.Interfaces.Repositories;
using JwtTokenService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace EntregasADomicilio.Web.Usuarios.BusinessLayer.Bl
{
    public class UsuarioBl : IUsuarioBl
    {
        //private readonly IUsuarioRepositorio _usuarioRepositorio;
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IRepositorio _repositorySql;
        private readonly JwtToken _jwtTokenService;

        public UsuarioBl(
            //UserManager<IdentityUser> userManager,
            //SignInManager<IdentityUser> signInManager,
            //IUsuarioRepositorio usuarioRepositorio,
            IConfiguration configuration,
            IRepositorio repositorySql,
            JwtToken jwtTokenService
        )
        {
            //_usuarioRepositorio = usuarioRepositorio;
            //_userManager = userManager;
            //_signInManager = signInManager;
            _configuration = configuration;
            _repositorySql = repositorySql;
            _jwtTokenService = jwtTokenService;
        }



        public async Task<TokenDto> LoginAsync(LoginDto login)
        {
            throw new NotImplementedException();
            //UsuarioEntity usuarioEntity;


            //usuarioEntity = await _usuarioRepositorio.ObtenerUsuarioAsync(login.Correo, login.Contrasenia);
            //if(usuarioEntity == null)
            //{
            //    return null;
            //}
            //else
            //{                
            //    Cliente cliente;

            //    cliente = await _repositorySql.Cliente.ObtenerPorUsuarioId(usuarioEntity.Id);

            //    return new TokenDto(
            //        _jwtTokenService.ObtenerToken(cliente.Nombre + " " + cliente.Apellidos, "Cliente", cliente.Id.ToString(), login.Correo, DateTime.Now.AddMinutes(20)),
            //         DateTime.Now.AddMinutes(20)
            //    );
            //}

            //var resultado = await _signInManager.PasswordSignInAsync(login.Correo, login.Contrasenia, isPersistent: false, lockoutOnFailure: false);
            //if (resultado.Succeeded)
            //{
            //    IdentityUser usuario;
            //    Cliente cliente;

            //    usuario = await _userManager.FindByEmailAsync(login.Correo);
            //    cliente = await _repositorySql.Cliente.ObtenerPorUsuarioId(usuario.Id);
            //    if (cliente == null)
            //        return null;

            //    return new TokenDto(
            //        _jwtTokenService.ObtenerToken(cliente.Nombre + " " + cliente.Apellidos, "Cliente", cliente.Id, login.Correo, DateTime.Now.AddMinutes(20)),
            //         DateTime.Now.AddMinutes(20)
            //    );

            //}
            //else
            //{
            //    return null;
            //}
        }

        //private async Task<TokenDto> ObtenerToken(LoginDto credenciales)
        //{
        //    var usuario = await _userManager.FindByEmailAsync(credenciales.Correo);

        //    TokenDto token;

        //    token = await _jwtTokenService.IniciarSesionAsync(
        //        usuario.UserName,
        //         await ObtenerRoleAsync(usuario),
        //         await ObtenerClienteIdAsync(usuario.Id),
        //         credenciales.Correo
        //    );


        //    //var claimsDb = await _userManager.GetClaimsAsync(usuario);
        //    //claims.AddRange(await ObtenerClaimsDeUsuarioAsync(usuario));
        //    //claims.AddRange(claimsDb);

        //    //var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["LLaveJwt"]));
        //    //var credential = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
        //    //var expiracion = DateTime.UtcNow.AddDays(1);
        //    //var token = new JwtSecurityToken(
        //    //    //issuer: null, 
        //    //    //audience: null, 
        //    //    claims: claims,
        //    //    expires: expiracion,
        //    //    signingCredentials: credential
        //    //);

        //    //return new TokenDto
        //    //{
        //    //    Token = new JwtSecurityTokenHandler().WriteToken(token),
        //    //    Expiracion = expiracion,
        //    //};

        //    return token;

        //}

        //private async Task<string> ObtenerRoleAsync(IdentityUser usuario)
        //{
        //    var claimsDb = await _userManager.GetClaimsAsync(usuario);
        //    var roles = _userManager.GetRolesAsync(usuario);
        //    var result = roles.Result;
        //    return claimsDb == null ? null : claimsDb.ToString();
        //}

        //private async Task<int> ObtenerClienteIdAsync(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //private async Task<string> AgregarUsuarioAsync(string correo, string contrasenia)
        //{
        //    IdentityUser identityUser;

        //    identityUser = new IdentityUser
        //    {
        //        UserName = correo,
        //        Email = correo
        //    };
        //    var resultado = await _userManager.CreateAsync(identityUser, contrasenia);

        //    return "";
        //}

        //private async Task<IEnumerable<Claim>> ObtenerClaimsDeUsuarioAsync(IdentityUser usuario)
        //{
        //    Cliente cliente;

        //    cliente = await _repositorySql.Cliente.ObtenerPorUsuarioId(usuario.Id);

        //    var claims = new List<Claim>
        //    {
        //            new Claim("Nombre", $"{cliente.Nombre} {cliente.Apellidos}"),
        //            new Claim("ClienteId", cliente.Id.ToString())
        //    };

        //    return claims;
        //}

        public async Task<string> AgregarAsync(UsuarioDtoIn usuario)
        {
            //IdentityUser identityUser;

            //identityUser = new IdentityUser
            //{
            //    UserName = usuario.Correo,
            //    Email = usuario.Correo
            //};
            //var resultado = await _userManager.CreateAsync(identityUser, usuario.Contrasenia);
            //await _userManager.AddClaimAsync(identityUser, new Claim("Role", usuario.Role));
            //if (!resultado.Succeeded)
            //{
            //    throw new Exception();
            //}

            //return identityUser.Id;

            return "";
        }
    }
}
