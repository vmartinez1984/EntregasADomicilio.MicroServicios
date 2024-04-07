using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Usuarios.Core.Dtos
{
    public class UsuarioDtoIn
    {

        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        [DefaultValue("")]
        public string Contrasenia { get; set; }

        [Required]
        [MaxLength(255)]
        [DataType(DataType.EmailAddress)]
        [DefaultValue("")]
        public string Correo { get; set; }
                
        [MinLength(1)]
        [MaxLength(255)]
        [DefaultValue("")]
        public string Nombre { get; set; }

        [Required]
        public ClienteDtoIn Cliente { get; set; }
    }

    public class ClienteDtoIn
    {
        [Required, MaxLength(50)]
        [DefaultValue("")]
        public string Nombre { get; set; }

        [Required, MaxLength(50)]
        [DefaultValue("")]
        public string Apellidos { get; set; }

        [Required, MaxLength(10), MinLength(10)]
        [DefaultValue("")]
        public string Telefono { get; set; }

        [Required]
        public DireccionDtoIn Direccion { get; set; }
    }

    public class DireccionDtoIn
    {
        [Required, MaxLength(255)]
        [DefaultValue("")]
        public string CalleYNumero { get; set; }

        [Required, MaxLength(255)]
        [DefaultValue("")]
        public string Alcaldia { get; set; }

        [Required, MaxLength(5), MinLength(5)]//42950
        [DefaultValue("")]
        public string CodigoPostal { get; set; }

        [Required, MaxLength(255), DefaultValue("")]
        public string Colonia { get; set; }

        [Required, MaxLength(255)]
        [DefaultValue("")]
        public string CoordenadasGps { get; set; }

        [Required, MaxLength(255)]
        [DefaultValue("")]
        public string Estado { get; set; }

        [Required, MaxLength(255)]
        [DefaultValue("")]
        public string Referencia { get; set; }
    }
}
