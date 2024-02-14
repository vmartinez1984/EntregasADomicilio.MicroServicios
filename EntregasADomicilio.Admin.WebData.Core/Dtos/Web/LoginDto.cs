using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Admin.WebData.Core.Dtos.Web
{
    public class LoginDto
    {
        [Required]
        public string Correo { get; set; }

        [Required]
        public string Contrasenia { get; set; }
    }
}
