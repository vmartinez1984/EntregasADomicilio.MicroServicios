using EntregasADomicilio.Admin.WebData.Core.Entities;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregasADomicilio.Core.Entities
{
    [FirestoreData]
    public class Pedido
    {
        [FirestoreProperty]
        [Key]
        public string Id { get; set; }

        [Required]
        public Guid Guid { get; set; } = Guid.NewGuid();

        [FirestoreProperty]
        public decimal Total { get; set; }

        [ForeignKey(nameof(Cliente))]
        public string ClienteId { get; set; }

        [FirestoreProperty]
        public Cliente Cliente { get; set; }

        [FirestoreProperty]
        public string Comentario { get; set; }

        [FirestoreProperty]
        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        [FirestoreProperty]
        public string Estatus { get; set; }

        public virtual List<DetalleDelPedido> ListaDetalleDelPedido { get; set; }

        [FirestoreProperty]
        public List<Platillo> Platillos { get; set; }
    }
}
