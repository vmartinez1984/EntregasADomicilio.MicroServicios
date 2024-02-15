using EntregasADomicilio.Admin.WebData.Core.Dtos.Admin;
using EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Admin.WebData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RestaurantesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RestauranteDto restaurante)
        {
            await _unitOfWork.Restaurante.AgregarAsync(restaurante);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Restaurante.ObtenerAsync());
        }
    }
}
