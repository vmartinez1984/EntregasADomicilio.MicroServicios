using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Admin.WebData.Core.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Correo { get; set; }

        [StringLength(50)]
        public string Telefono { get; set; }

        [StringLength(36)]
        public string UsuarioId { get; set; }

        [StringLength(50)]
        public string Apellidos { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }

        public virtual List<Direccion> Direcciones { get; set; }
    }
}
