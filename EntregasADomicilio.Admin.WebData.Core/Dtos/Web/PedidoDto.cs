using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Admin.WebData.Core.Dtos.Web
{
    public class PedidoDtoIn
    {
        [Required]
        public List<PlatilloDtoIn> ListaDetalleDelPedido { get; set; }

        [Required]
        public string Comentario { get; set; }
    }

    public class PlatilloDtoIn
    {
        [Required]
        public int PlatilloId { get; set; }

        [Required]
        public decimal Precio { get; set; }

    }

    public class PedidoDto
    {
        public int Id { get; set; }

        public List<PlatilloDto> ListaDetalleDelPedido { get; set; }

        public string Comentario { get; set; }

        public string Estatus { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        public decimal Total { get; set; }
    }
}
