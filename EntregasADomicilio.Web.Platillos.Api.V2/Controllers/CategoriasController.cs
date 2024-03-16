using EntregasADomicilio.Web.Platillos.Api.V2.Dtos;
using EntregasADomicilio.Web.Platillos.Api.V2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Web.Platillos.Api.V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IRepositorio _repositorio;

        public CategoriasController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<CategoriaDto> categorias;

            categorias = (await _repositorio.Categoria.ObtenerTodosAsync()).Select(c => new CategoriaDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
            }).ToList();

            return Ok(categorias);
        }
    }
}
