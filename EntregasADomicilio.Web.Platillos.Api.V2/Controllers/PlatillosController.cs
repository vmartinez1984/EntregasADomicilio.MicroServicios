using Microsoft.AspNetCore.Mvc;
using EntregasADomicilio.Web.Platillos.Api.V2.Interfaces;
using EntregasADomicilio.Web.Platillos.Api.V2.Dtos;
using EntregasADomicilio.Web.Platillos.Api.V2.Entities;
using EntregasADomicilio.StoreFiles;

namespace EntregasADomicilio.Web.Platillos.Api.V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatillosController : ControllerBase
    {
        private readonly IRepositorio _repositorio;
        private readonly AlmacenDeArchivosFirebase _almacenDeArchivosFirebase;

        public PlatillosController(IRepositorio repositorio, AlmacenDeArchivosFirebase almacenDeArchivosFirebase)
        {
            _repositorio = repositorio;
            _almacenDeArchivosFirebase = almacenDeArchivosFirebase;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<PlatilloDto> categorias;

            categorias = (await _repositorio.Platillo.ObtenerTodosAsync()).Select(c => new PlatilloDto
            {
                Id = c.Id,
                Categoria = c.CategoriaNombre,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Precio = c.Precio
            }).ToList();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            PlatilloDto platilloDto;
            Platillo c;

            c = await _repositorio.Platillo.ObtenerPorIdAsync(id.ToString());
            platilloDto = new PlatilloDto
            {
                Id = c.Id,
                Categoria = c.CategoriaNombre,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Precio = c.Precio
            };

            return Ok(platilloDto);
        }

        /// <summary>
        /// Obtiene la imagen del platillo por id
        /// </summary>
        /// <param name="platilloId"></param>        
        [HttpGet("{platilloId}/Imagen")]
        public async Task<IActionResult> ObtenerImagenPorPlatilloId(Guid platilloId)
        {
            byte[] bytes;
            Platillo platillo;

            platillo = await _repositorio.Platillo.ObtenerPorIdAsync(platilloId.ToString());
            bytes = await ObtenerBytesDeAlmacenAsync(platillo.ListaDeArchivos, "FirebaseStorage");

            return File(bytes, "image/png");
        }

        private async Task<byte[]> ObtenerBytesDeAlmacenAsync(List<Archivo> listaDeArchivos, string almacen)
        {
            byte[] bytes = null;
            Archivo archivo;


            archivo = listaDeArchivos.Where(x => x.NombreDelAlmacen == almacen).FirstOrDefault();
            if (archivo != null)
                bytes = await _almacenDeArchivosFirebase.Obtener(archivo.RutaDelArchivo);

            return bytes;
        }
    }
}
