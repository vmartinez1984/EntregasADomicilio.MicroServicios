using System;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Admin.WebData.Core.Dtos.Web
{
    public class ClienteDto
    {
        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string Correo { get; set; }

        [MaxLength(20)]
        public string Contrasenia { get; set; }

        [MaxLength(50)]
        public string Telefono { get; set; }

        [MaxLength(50)]
        public string Apellidos { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }

        public DireccionDtoIn Direccion { get; set; }
    }

    public class DireccionDtoIn
    {
        [MaxLength(250)]
        public string CalleYNumero { get; set; }

        [MaxLength(250)]
        public string Referencias { get; set; }

        [MaxLength(250)]
        public string Alcaldia { get; set; }

        [MaxLength(250)]
        public string Estado { get; set; }

        [MaxLength(5)]
        public string CodigoPostal { get; set; }

        [MaxLength(25)]
        public string? Latitud { get; set; }

        [MaxLength(25)]
        public string? Longitud { get; set; }
    }

    public class ClienteDtoIn
    {
        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string Correo { get; set; }

        [MaxLength(20)]
        public string Contrasenia { get; set; }

        [MaxLength(50)]
        public string Telefono { get; set; }

        [MaxLength(50)]
        public string Apellidos { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }

        public DireccionVentaDtoIn Direccion { get; set; }
    }
}
