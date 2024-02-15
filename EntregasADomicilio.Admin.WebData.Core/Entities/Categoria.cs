using System;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Core.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid Guid { get; set; } = Guid.NewGuid();

        [MaxLength(50)]
        public string Nombre { get; set; }

        public bool EstaActivo { get; set; } = true;
    }
}
