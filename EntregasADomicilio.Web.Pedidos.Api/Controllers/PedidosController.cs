using EntregasADomicilio.Web.Pedidos.BusinessLayer;
using EntregasADomicilio.Web.Pedidos.Core.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        /// <response code="202"></response>
        [HttpPost]
        [ProducesResponseType(typeof(IdDto), 202)]
        [Produces("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cliente")]
        //[AllowAnonymous]
        public async Task<IActionResult> AgregarPedido(PedidoDtoIn pedido)
        {
            PedidoDto pedidoDto;

            pedidoDto = await _unitOfWork.ObtenerAsync(pedido.Id.ToString());
            if(pedidoDto is not null)
                return Ok(pedidoDto);
            string id;

            string clienteId = ObtenerClienteId();
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
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cliente")]
        //[AllowAnonymous]
        public async Task<IActionResult> ObtenerPedido(Guid pedidoId)
        {
            PedidoDto pedido;

            pedido = await _unitOfWork.ObtenerAsync(pedidoId.ToString());            
            if (pedido is null)
                return NotFound();

            return Ok(pedido);
        }

        /// <summary>
        /// Obtiene la lista de pedidos del cliente
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(PedidoDto), 200)]
        [Produces("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cliente")]
        public async Task<IActionResult> ObtenerTodos()
        {
            List<PedidoDto> pedidos;
            string clienteId;

            clienteId =ObtenerClienteId();
            pedidos = await _unitOfWork.ObtenerTodosPorClienteIdAsync(clienteId);

            return Ok(pedidos);
        }
    }
}
