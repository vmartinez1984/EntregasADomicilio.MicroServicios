using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregasADomicilio.Web.Platillos.Core.Entities
{
    public class Archivo
    {
        [Key]
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string NombreDelArchivo { get; set; }

        public string AliasDelArchivo { get; set; }

        public string RutaDelArchivo { get; set; }

        public string ContentType { get; set; }

        public string NombreDelAlmacen { get; set; }

        [ForeignKey(nameof(Platillo))]
        public int PlatilloId { get; set; }

        public virtual Platillo Platillo { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        public bool EstaActivo { get; set; }
    }
}
