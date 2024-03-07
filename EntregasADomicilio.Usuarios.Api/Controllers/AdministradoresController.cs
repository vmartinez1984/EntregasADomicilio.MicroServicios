using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Usuarios.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AgregarAdministrador()
        {
            return Ok();
        }

        [HttpPost("Repartidores")]
        public async Task<IActionResult> AgregarRepartidor()
        {
            return Ok();
        }

        [HttpPost("Operadores")]
        public async Task<IActionResult> AgregarOperadores()
        {
            return Ok();
        }
    }
}
