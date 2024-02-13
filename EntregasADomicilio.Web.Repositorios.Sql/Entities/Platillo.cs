using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace EntregasADomicilio.Web.Repositorios.Sql.Entities
{
    public class Platillo
    {
        [Key]
        public int Id { get; set; }

        public Guid Guid { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(250)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        public decimal Precio { get; set; }

        public bool EstaActivo { get; set; } = true;

        [Required(ErrorMessage = "Seleccione una categoria")]
        [Display(Name = "Categoria")]
        [ForeignKey(nameof(Categoria))]
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        public List<Archivo> ListaDeArchivos { get; set; }
    }
}
