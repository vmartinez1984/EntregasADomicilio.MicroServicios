using EntregasADomicilio.Web.Platillos.BusinessLayer.Interfaces;
using EntregasADomicilio.Web.Platillos.BusinessLayer.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Web.Platillos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWorkBl _unitOfWorkBl;

        public CategoriasController(IUnitOfWorkBl unitOfWorkBl)
        {
            this._unitOfWorkBl = unitOfWorkBl;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<CategoriaDto> categoriaDtos;

            categoriaDtos = await _unitOfWorkBl.Categoria.ObtenerTodos();

            return Ok(categoriaDtos);
        }
    }
}
