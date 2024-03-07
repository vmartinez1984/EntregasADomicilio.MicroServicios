using EntregasADomicilio.Usuarios.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Usuarios.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepartidoresController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]InicioDeSesionDto inicioDeSesion)
        {
            return Ok();
        }


    }
}
