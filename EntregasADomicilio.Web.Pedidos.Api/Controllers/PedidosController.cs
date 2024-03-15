using EntregasADomicilio.Web.Pedidos.BusinessLayer;
using EntregasADomicilio.Web.Pedidos.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Web.Pedidos.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoBl _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        public PedidosController(IPedidoBl unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Registrar pedido
        /// </summary>
        /// <param name="pedido"></param>
        /// <param name="clienteId"></param>
        /// <response code="202"></response>
        [HttpPost("clientes/{clienteId}")]
        [ProducesResponseType(typeof(IdDto), 202)]
        [Produces("application/json")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cliente")]
        [AllowAnonymous]
        public async Task<IActionResult> AgregarPedido(PedidoDtoIn pedido, string clienteId)
        {
            string id;

            //var clienteID = ObtenerClienteId();
            id = await _unitOfWork.AgregarAsync(pedido, clienteId);

            return Created($"Pedidos/{id}", new IdDto { Guid = pedido.Id });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected string ObtenerClienteId()
        {
            //string clienteId;

            var claim = this.HttpContext.User.Claims.First(x => x.Type == "ClienteId");
            //clienteId = int.Parse(claim.Value);

            return claim.Value;
        }

        /// <summary>
        /// Obtener pedido por número de pedido
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <returns></returns>
        [HttpGet("{pedidoId}")]
        [ProducesResponseType(typeof(PedidoDto), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> ObtenerPedido(string pedidoId)
        {
            PedidoDto pedido;

            pedido = await _unitOfWork.ObtenerAsync(pedidoId);

            return Ok(pedido);
        }

        /// <summary>
        /// Obtiene la lista de pedidos del cliente
        /// </summary>
        /// <returns></returns>
        [HttpGet("clientes/{clienteId}")]
        [ProducesResponseType(typeof(PedidoDto), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> ObtenerTodos(string clienteId)
        {
            List<PedidoDto> pedidos;

            pedidos = await _unitOfWork.ObtenerTodosPorClienteIdAsync(clienteId);

            return Ok(pedidos);
        }
    }
}
