using System;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Web.Repositorios.Sql.Entities
{
    public class Categoria
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        public bool EstaActivo { get; set; } = true;
    }
}
