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
    public class PedidosController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        public PedidosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Registrar pedido
        /// </summary>
        /// <param name="pedido"></param>
        /// <response code="202"></response>
        [HttpPost]
        [ProducesResponseType(typeof(IdDto), 202)]
        [Produces("application/json")]
        public async Task<IActionResult> AgregarPedido(PedidoDtoIn pedido)
        {
            IdDto id;
            int clienteId;

            clienteId = ObtenerClienteId();
            id = await _unitOfWork.Pedido.AgregarAsync(pedido, clienteId);

            return Created($"/Pedidos/{id.Id}", id);
        }

        protected int ObtenerClienteId()
        {
            int clienteId;

            var claim = this.HttpContext.User.Claims.First(x => x.Type == "ClienteId");
            clienteId = int.Parse(claim.Value);

            return clienteId;
        }

        /// <summary>
        /// Obtener pedido por número de pedido
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <returns></returns>
        [HttpGet("{pedidoId}")]
        [ProducesResponseType(typeof(PedidoDto), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> ObtenerPedido(int pedidoId)
        {
            PedidoDto pedido;

            pedido = await _unitOfWork.Pedido.ObtenerPorIdAsync(pedidoId);

            return Ok(pedido);
        }

        /// <summary>
        /// Obtiene la lista de pedidos del cliente
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PedidoDto), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> ObtenerTodos()
        {
            List<PedidoDto> pedidos;

            pedidos = await _unitOfWork.Pedido.ObtenerTodosPorClienteId(ObtenerClienteId());

            return Ok(pedidos);
        }
    }
}
