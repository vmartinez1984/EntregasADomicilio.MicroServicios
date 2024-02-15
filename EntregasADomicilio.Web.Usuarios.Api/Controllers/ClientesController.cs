using EntregasADomicilio.Admin.WebData.Core.Dtos.Web;
using EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Usuarios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Web.Usuarios.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cliente")]
    public class ClientesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ClientesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Registra cliente en el sistema
        /// </summary>
        /// <param name="clienteDtoIn"></param>
        /// <response code="202">Registrado</response>
        [HttpPost]
        [ProducesResponseType(typeof(IdDto), StatusCodes.Status202Accepted)]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] ClienteDtoIn clienteDtoIn)
        {
            int id;

            id = await _unitOfWork.Cliente.AgregarAsync(clienteDtoIn);

            return Accepted(new IdDto { Guid = clienteDtoIn.Guid, Id = id });
        }

        /// <summary>
        /// Inicia sesión 
        /// </summary>
        /// <param name="login"></param>
        /// <response code="200">Token</response>
        [HttpPost("InicioDeSesion")]
        [ProducesResponseType(typeof(TokenDto), StatusCodes.Status200OK)]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginDto login)
        {
            TokenDto token;

            token = await _unitOfWork.Usuario.LoginAsync(login);
            if (token == null)
            {
                return NotFound(new { Mensaje = "Correo y/o contraseña incorrectos" });
            }

            return Ok(token);
        }

        /// <summary>
        /// Obtener cliente
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> ObtenerCliente()
        {
            ClienteDto cliente;

            cliente = await _unitOfWork.Cliente.ObtenerPorIdAsync(ObtenerClienteId());

            return Ok(cliente);
        }

        private int ObtenerClienteId()
        {
            int clienteId;

            var claim = this.HttpContext.User.Claims.First(x => x.Type == "ClienteId");
            clienteId = int.Parse(claim.Value);

            return clienteId;
        }

        /*

        /// <summary>
        /// Actualizar datos del cliente/ no implementado
        /// </summary>
        /// <param name="cliente"></param>
        /// <response code="200">Token</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [Produces("application/json")]
        public async Task<IActionResult> ActualizarCliente([FromBody] ClienteVentaDtoUpdate cliente)
        {
            int clienteId;

            clienteId = ObtenerClienteId();
            await _unitOfWork.Cliente.ActualizarAsync(clienteId, cliente);

            return Accepted();
        }


        /// <summary>
        /// Agregar direccion del cliente
        /// </summary>
        /// <param name="direccion"></param>
        /// <response code="200">Token</response>
        [HttpPost("{clienteId}/Direcciones")]
        [ProducesResponseType(typeof(IdDto), StatusCodes.Status202Accepted)]
        [Produces("application/json")]
        public async Task<IActionResult> AgregarDireccion([FromBody] DireccionVentaDtoIn direccion)
        {
            int clienteId;
            int direccionId;

            clienteId = ObtenerClienteId();
            direccionId = await _unitOfWork.Cliente.AgregarDireccionAsync(clienteId, direccion);

            return Accepted(new { DireccionId = direccionId });
        }

        /// <summary>
        /// Actualizar direccion del cliente
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="direccionId"></param>
        /// <response code="200">Token</response>
        [HttpPut("Direcciones/{direccionId}")]
        [ProducesResponseType(typeof(IdDto), StatusCodes.Status202Accepted)]
        [Produces("application/json")]
        public async Task<IActionResult> ActualizarDireccion(int direccionId, [FromBody] DireccionVentaDtoIn direccion)
        {
            await _unitOfWork.Cliente.ActualizarDireccionAsync(direccionId, direccion);

            return Accepted();
        }

        /// <summary>
        /// Colocar como princial
        /// </summary>
        /// <param name="direccionId"></param>
        /// <response code="200"></response>
        [HttpPut("Direcciones/Orden")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [Produces("application/json")]
        public async Task<IActionResult> ColocarComoPrincipalAsync(int direccionId)
        {
            await _unitOfWork.Cliente.ColocarComoPrincipalAsync(direccionId, ObtenerClienteId());

            return Accepted();
        }
        */
    }
}
