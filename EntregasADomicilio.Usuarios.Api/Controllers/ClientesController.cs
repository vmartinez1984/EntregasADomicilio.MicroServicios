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
        public async Task<IActionResult> AgregarAsync([FromBody] ClienteDtoIn clientte)
        {
            await _unitOfWork.Cliente.AgregarAsync(clientte);

            return Created("", new { Id = clientte.Id });
        }

        [HttpPost("IniciarSesion")]
        [AllowAnonymous]
        public async Task<IActionResult> IniciarSesion(InicioDeSesionDto inicioDeSesion)
        {
            TokenDto tokenDto;

            tokenDto = await _unitOfWork.Cliente.IniciarSesionAsync(inicioDeSesion);

            return Ok(tokenDto);
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar(ClienteDtoIn cliente)
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

        [HttpGet("Id")]
        public async Task<IActionResult> ObtenerId()
        {
            string clienteId;

            clienteId = ObtenerClienteId();

            return Ok(new { Id = clienteId });
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerCliente()
        {
            ClienteDto cliente;

            cliente = await _unitOfWork.Cliente.ObtenerAsync(ObtenerClienteId());

            return Ok(cliente);
        }
    }
}
