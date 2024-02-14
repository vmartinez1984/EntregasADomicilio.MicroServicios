using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregasADomicilio.Admin.Repositorio.Sql.Entities
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

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
