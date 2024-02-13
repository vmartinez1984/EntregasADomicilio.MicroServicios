using EntregasADomicilio.Web.Platillos.Dtos;
using EntregasADomicilio.Web.Repositorios.Sql.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Web.Platillos.Controllers
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
            List<CategoriaDto> categoriaDtos;            

            categoriaDtos = (await _repositorio.Categoria.ObtenerTodos())
                .Select(c => new CategoriaDto { Id  = c.Id, Nombre = c.Nombre })
                .ToList();

            return Ok(categoriaDtos);
        }
    }
}
