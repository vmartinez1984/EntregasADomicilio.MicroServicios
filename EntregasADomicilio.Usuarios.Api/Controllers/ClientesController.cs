using EntregasADomicilio.Usuarios.BusinessLayer.Bl;
using EntregasADomicilio.Usuarios.Core.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Usuarios.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cliente")]
    public class ClientesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public ClientesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AgregarAsync([FromBody] UsuarioDtoIn usuario)
        {
            await _unitOfWork.Cliente.AgregarAsync(usuario);

            return Created("", new { Id = usuario.Id });
        }

        [HttpPost("IniciarSesion")]
        [AllowAnonymous]
        public async Task<IActionResult> IniciarSesion(InicioDeSesionDto inicioDeSesion)
        {
            TokenDto tokenDto;

            tokenDto = await _unitOfWork.Cliente.IniciarSesionAsync(inicioDeSesion);
            if (tokenDto == null)
                return NotFound(new { Mensaje = "Contraseña y/o correno incorrectos" });

            return Ok(tokenDto);
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar(UsuarioDtoIn cliente)
        {
            string clienteId;

            clienteId = ObtenerClienteId();

            return Accepted();
        }

        protected string ObtenerClienteId()
        {
            //string clienteId;

            var claim = this.HttpContext.User.Claims.First(x => x.Type == "ClienteId");
            //clienteId = int.Parse(claim.Value);

            return claim.Value;
        }

        [HttpGet("{clienteId}")]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerId(Guid clienteId)
        {
            //string clienteId;

            //clienteId = ObtenerClienteId();

            //return Ok(new { Id = clienteId });
            ClienteDto cliente;

            cliente = await _unitOfWork.Cliente.ObtenerAsync(clienteId);

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerCliente()
        {
            ClienteDto cliente;

            cliente = await _unitOfWork.Cliente.ObtenerAsync(Guid.Parse( ObtenerClienteId()));

            return Ok(cliente);
        }
    }
}
