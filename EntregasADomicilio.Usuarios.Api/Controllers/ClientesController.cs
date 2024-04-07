using EntregasADomicilio.Usuarios.BusinessLayer.Bl;
using EntregasADomicilio.Usuarios.Core.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Usuarios.Api.Controllers
{
    /// <summary>
    /// Api para la administración de clientes desde la pagína web o app mobile
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cliente")]
    public class ClientesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ClientesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Registrar nuevo usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <response code="201">Usuario creado</response>
        /// <response code="200">Usuario registrado anteriormente</response>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IdDto), 201)]
        [ProducesResponseType(typeof(ClienteDto), 200)]
        public async Task<IActionResult> AgregarAsync([FromBody] UsuarioDtoIn usuario)
        {
            ClienteDto clienteDto;

            clienteDto = await _unitOfWork.Cliente.ObtenerAsync(usuario.Id);
            if(clienteDto is not null)
                return Ok(clienteDto);
            await _unitOfWork.Cliente.AgregarAsync(usuario);

            return Created("", new IdDto {  Id = usuario.Id });
        }

        /// <summary>
        /// Iniciar sesión
        /// </summary>
        /// <param name="inicioDeSesion"></param>
        /// <response code="200">Token</response>
        /// <response code="404">Contraseña y/o correo incorrectos</response>
        [HttpPost("IniciarSesion")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(TokenDto), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> IniciarSesion(InicioDeSesionDto inicioDeSesion)
        {
            TokenDto tokenDto;

            tokenDto = await _unitOfWork.Cliente.IniciarSesionAsync(inicioDeSesion);
            if (tokenDto == null)
                return NotFound(new { Mensaje = "Contraseña y/o correo incorrectos" });

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
