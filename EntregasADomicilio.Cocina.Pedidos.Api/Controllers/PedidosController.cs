using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Cocina.Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> ObtenerTodos(string estado = null)
        {

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> CambiarEstado([FromQuery]Guid id, [FromBody]string estado)
        {

            return Accepted();
        }

        [HttpGet("Estados")]
        public IActionResult ObtenerEstados()
        {
            List<string> lista = new List<string>();

            lista.Add("Preparando");
            lista.Add("Listo para entregar");

            return Ok(lista);
        }
    }
}
