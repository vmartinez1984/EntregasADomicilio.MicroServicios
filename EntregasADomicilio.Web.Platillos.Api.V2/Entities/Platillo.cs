using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Google.Cloud.Firestore;

namespace EntregasADomicilio.Web.Platillos.Api.V2.Entities
{
    [FirestoreData]
    public class Platillo
    {
        [FirestoreProperty]        
        public string Id { get; set; }
               
        [FirestoreProperty]
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [FirestoreProperty]
        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(250)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [FirestoreProperty]
        [Required(ErrorMessage = "El precio es requerido")]
        public double Precio { get; set; }

        [FirestoreProperty]
        public bool EstaActivo { get; set; } = true;

        [Required(ErrorMessage = "Seleccione una categoria")]
        [Display(Name = "Categoria")]
        [ForeignKey(nameof(Categoria))]
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        [FirestoreProperty("Categoria")]
        public string CategoriaNombre { get; set; }

        [FirestoreProperty]
        public List<Archivo> ListaDeArchivos { get; set; }
    }
}
