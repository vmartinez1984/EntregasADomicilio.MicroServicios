using EntregasADomicilio.Admin.WebData.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregasADomicilio.Core.Entities
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid Guid { get; set; } = Guid.NewGuid();

        public decimal Total { get; set; }

        [ForeignKey(nameof(Cliente))]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public string Comentario { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        public string Estatus { get; set; }

        public virtual List<DetalleDelPedido> ListaDetalleDelPedido { get; set; }
    }
}
