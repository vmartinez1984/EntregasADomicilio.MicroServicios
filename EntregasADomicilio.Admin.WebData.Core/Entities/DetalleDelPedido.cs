﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregasADomicilio.Core.Entities
{
    public class DetalleDelPedido
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Pedido))]
        public int PedidoId { get; set; }

        //public virtual Pedido Pedido { get; set; }

        [ForeignKey(nameof(Platillo))]
        public string PlatilloId { get; set; }

        public virtual Platillo Platillo { get; set; }

        public decimal Precio { get; set; }
    }
}
