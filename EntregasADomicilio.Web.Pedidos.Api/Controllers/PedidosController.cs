using EntregasADomicilio.Admin.WebData.Core.Dtos.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cliente")]
    public class PedidosController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        public PedidosController(IUnitOfWorkVentas unitOfWork) 
        {
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
            int id;
            int clienteId;

            clienteId = ObtenerClienteId();
            id = await _unitOfWork.Pedido.AgregarAsync(pedido, clienteId);

            return Created("", new { Id = id });
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
        /// Obtener pedido por número de pedido
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <returns></returns>
        [HttpGet("{pedidoId}")]
        [ProducesResponseType(typeof(PedidoDto), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> ObtenerPedido(int pedidoId)
        {

            return Ok(new PedidoDto());
        }

        /// <summary>
        /// Obtiene la lista de pedidos del cliente
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PedidoVentaDto), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> ObtenerTodos()
        {
            List<PedidoVentaDto> pedidos;

            pedidos = await _unitOfWork.Pedido.ObtenerTodosPorClienteId(ObtenerClienteId());

            return Ok(pedidos);
        }*/
    }
}
