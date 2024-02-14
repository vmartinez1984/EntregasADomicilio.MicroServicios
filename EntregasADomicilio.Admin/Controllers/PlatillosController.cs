using EntregasADomicilio.Admin.BusinessLayer.Bl;
using EntregasADomicilio.Admin.BusinessLayer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatillosController : ControllerBase
    {
        private readonly UnitOfWorkBl _unitOfWork;

        public PlatillosController(UnitOfWorkBl unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene los platillos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            List<PlatilloDto> platillos;

            platillos = await _unitOfWork.Platillo.ObtenerTodosAsync(true);

            return Ok(platillos);
        }

        /// <summary>
        /// Obtiene la imagen del platillo por id
        /// </summary>
        /// <param name="platilloId"></param>        
        [HttpGet("{platilloId}/Imagen")]
        public async Task<IActionResult> ObtenerImagenPorPlatilloId(int platilloId)
        {
            byte[] bytes;

            bytes = await _unitOfWork.Platillo.ObtenerBytesAsync(platilloId);

            return File(bytes, "image/png");
            //return File(memoryStream.ToArray(), "image/png", fileDownloadName: data.ObjectName); 
        }

        /// <summary>
        /// Obtine el platillo por platilloId
        /// </summary>
        /// <param name="platilloId"></param>
        /// <response code="200">PlatilloDto</response>
        [HttpGet("{platilloId}")]
        public async Task<IActionResult> ObtenerPorPlatilloId(int platilloId)
        {
            PlatilloDto platillo;

            platillo = await _unitOfWork.Platillo.ObtenerPorId(platilloId);

            return Ok(platillo);
        }

        /// <summary>
        /// Agregar un platillo al menu
        /// </summary>
        /// <param name="platillo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] PlatilloDtoIn platillo)
        {
            int id;

            id = await _unitOfWork.Platillo.AgregarAsync(platillo);

            return Created($"Platillos/{id}", new { Id = id });
        }

        /// <summary>
        /// No implementado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="platillo"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] PlatilloDtoIn platillo)
        {
            await _unitOfWork.Platillo.ActualizarAsync(id, platillo);

            return Accepted();
        }

        /// <summary>
        /// Borrar por su id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.Platillo.BorrarAsync(id);

            return Accepted();
        }
    }
}
