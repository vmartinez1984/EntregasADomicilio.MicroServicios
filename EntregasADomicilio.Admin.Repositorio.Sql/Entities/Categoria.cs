using System;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Admin.Repositorio.Sql.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        public Guid Guid { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        public bool EstaActivo { get; set; } = true;
    }
}
