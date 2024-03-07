using Google.Cloud.Firestore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregasADomicilio.Web.Platillos.Core.Entities
{
    [FirestoreData]
    public class Categoria
    {
        [FirestoreProperty]
        [Key]
        public string Id { get; set; }

        [NotMapped]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [Required]
        [BsonElement("guid")]
        public Guid Guid { get; set; }

        [FirestoreProperty]
        [MaxLength(50)]
        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [FirestoreProperty]
        [BsonElement("estaActivo")]
        public bool EstaActivo { get; set; } = true;
    }
}
