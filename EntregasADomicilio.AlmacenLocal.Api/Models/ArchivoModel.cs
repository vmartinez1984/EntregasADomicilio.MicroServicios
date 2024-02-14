using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.AlmacenLocal.Api.Models
{
    public class ArchivoModel
    {
        [Required]
        public IFormFile FormFile { get; set; }

        public string? NombreDelArchivo { get; set; }
    }
}
