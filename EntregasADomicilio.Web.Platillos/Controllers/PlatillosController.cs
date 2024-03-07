using EntregasADomicilio.Web.Platillos.BusinessLayer.Dtos;
using EntregasADomicilio.Web.Platillos.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Web.Platillos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatillosController : ControllerBase
    {
        private readonly IUnitOfWorkBl _unitOfWorkBl;

        public PlatillosController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<PlatilloDto> platilloDtos;

            platilloDtos = await _unitOfWorkBl.Platillo.ObtnerTodos();

            return Ok(platilloDtos);
        }

        /// <summary>
        /// Obtiene la imagen del platillo por id
        /// </summary>
        /// <param name="platilloId"></param>        
        [HttpGet("{platilloId}/Imagen")]
        public async Task<IActionResult> ObtenerImagenPorPlatilloId(Guid platilloId)
        {
            byte[] bytes;

            bytes = await _unitOfWorkBl.Platillo.ObtenerBytesAsync(platilloId);

            return File(bytes, "image/png");            
        }
    }
}
