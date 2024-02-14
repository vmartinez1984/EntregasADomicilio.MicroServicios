using EntregasADomicilio.AlmacenLocal.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.AlmacenLocal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivosController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;

        public ArchivosController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        /// <summary>
        /// Agregar archivo
        /// </summary>
        /// <param name="contenedor">Folder o carpeta</param>
        /// <param name="formFile">Archivo a registrar</param>
        /// <response code="201"></response>
        [HttpPost("{contenedor}")]
        public async Task<IActionResult> AgregarArchivo([Required] string contenedor, [FromForm] ArchivoModel archivo)
        {
            if (string.IsNullOrEmpty(archivo.NombreDelArchivo))
            {
                Guid id = Guid.NewGuid();
                archivo.NombreDelArchivo = id + Path.GetExtension(archivo.FormFile.FileName);
            }
            string folder = Path.Combine(environment.WebRootPath, contenedor);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string ruta = Path.Combine(folder, archivo.NombreDelArchivo);
            using (var memoryStream = new MemoryStream())
            {
                await archivo.FormFile.CopyToAsync(memoryStream);
                var contenido = memoryStream.ToArray();
                await System.IO.File.WriteAllBytesAsync(ruta, contenido);
            }

            return Created(
                Path.Combine(contenedor, archivo.NombreDelArchivo)
                , new IdModel
                {
                    Id = archivo.NombreDelArchivo
                });
        }
    }
}
