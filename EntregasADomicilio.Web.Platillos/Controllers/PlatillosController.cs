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
            this._unitOfWorkBl = unitOfWorkBl;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<PlatilloDto> platilloDtos;

            platilloDtos = await _unitOfWorkBl.Platillo.ObtnerTodos();

            return Ok(platilloDtos);
        }

        //private CategoriaDto ObtenerCategoria(Categoria categoria)
        //{
        //    return new CategoriaDto { Nombre = categoria.Nombre, Id = categoria.Id };
        //}
    }
}
