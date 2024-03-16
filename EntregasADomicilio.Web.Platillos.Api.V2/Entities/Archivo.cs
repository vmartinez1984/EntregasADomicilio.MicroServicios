using Google.Cloud.Firestore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregasADomicilio.Web.Platillos.Api.V2.Entities
{
    [FirestoreData]
    public class Archivo
    {
        [FirestoreProperty]
        [Key]
        public string Id { get; set; }

        public Guid Guid { get; set; }

        [FirestoreProperty]
        public string NombreDelArchivo { get; set; }

        [FirestoreProperty]
        public string AliasDelArchivo { get; set; }

        [FirestoreProperty]
        public string RutaDelArchivo { get; set; }

        [FirestoreProperty]
        public string ContentType { get; set; }

        [FirestoreProperty]
        public string NombreDelAlmacen { get; set; }

        [ForeignKey(nameof(Platillo))]
        public int PlatilloId { get; set; }

        public virtual Platillo Platillo { get; set; }

        [FirestoreProperty]
        public DateTime FechaDeRegistro { get; set; }

        [FirestoreProperty]
        public bool EstaActivo { get; set; }
    }
}
