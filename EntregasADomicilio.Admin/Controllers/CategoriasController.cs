using EntregasADomicilio.Admin.BusinessLayer.Bl;
using EntregasADomicilio.Admin.BusinessLayer.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly UnitOfWorkBl _unitOfWork;

        public CategoriasController(UnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWork = unitOfWorkBl;
        }

        /// <summary>
        /// Lista de categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<CategoriaDto>> Get()
        {
            List<CategoriaDto> lista;

            lista = await _unitOfWork.Categoria.ObtenerTodos();

            return lista;
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaDtoIn categoria)
        {
            string id;
            CategoriaDto categoriaDto;
            if (categoria.Id == Guid.Empty)
                categoriaDto = await _unitOfWork.Categoria.ObtenerPorGuid(categoria.Id);
            else
                categoriaDto = null;
            if (categoriaDto is not null)
            {
                return Ok(categoriaDto);
            }
            id = await _unitOfWork.Categoria.Agregar(categoria);

            return Created($"/Categorias/{id}", new { Id = id });
        }

        /// <summary>
        /// ACtualizar categoria
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoria"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CategoriaDtoUpdate categoria)
        {
            await _unitOfWork.Categoria.Actualizar(id, categoria);

            return Accepted();
        }
    }
}
