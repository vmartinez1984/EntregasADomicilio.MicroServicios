using AutoMapper;
using EntregasADomicilio.Web.Platillos.Dtos;
using EntregasADomicilio.Web.Repositorios.Sql.Entities;
using EntregasADomicilio.Web.Repositorios.Sql.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Web.Platillos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatillosController : ControllerBase
    {
        private readonly IRepositorio _repositorio;
        //private readonly IMapper _mapper;

        public PlatillosController(IRepositorio repositorio
        //    , IMapper mapper
        )
        {
            _repositorio = repositorio;
           // _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<PlatilloDto> platilloDtos;
            List<Platillo> platillos;

            platillos = await _repositorio.Platillo.ObtenerTodos();            
            platilloDtos = platillos.Select(x => new PlatilloDto { 
                Categoria = ObtenerCategoria(x.Categoria),
                Id = x.Id,
                Nombre = x.Nombre,
                Precio = x.Precio,                
                Descripcion = x.Descripcion                
            }).ToList();

            return Ok(platilloDtos);
        }

        private CategoriaDto ObtenerCategoria(Categoria categoria)
        {
            return new CategoriaDto { Nombre = categoria.Nombre, Id = categoria.Id };
        }
    }
}
