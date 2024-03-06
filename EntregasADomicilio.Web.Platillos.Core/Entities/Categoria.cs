using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregasADomicilio.Web.Platillos.Core.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [NotMapped]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [Required]
        [BsonElement("guid")]
        public Guid Guid { get; set; }

        [MaxLength(50)]
        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("estaActivo")]
        public bool EstaActivo { get; set; } = true;
    }
}
