using System;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Admin.WebData.Core.Dtos.Web
{
    public class UsuarioDtoIn
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }

        public string Correo { get; set; }

        [Required]
        public string Contrasenia { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Telefono { get; set; }
    }
}
