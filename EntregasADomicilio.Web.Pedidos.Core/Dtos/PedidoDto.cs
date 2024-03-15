using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Web.Pedidos.Core.Dtos
{
    public class PedidoDtoIn
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        //public decimal Total { get; set; }

        //public string Estado { get; set; }

        //public DireccionDtoIn Direccion { get; set; }
        [Required]
        public List<PlatilloDtoIn> Platillos { get; set; }
        public string Comentario { get; set; }        
    }

    public class PedidoDto
    {
        public Guid Id { get; set; }

        public List<PlatilloDto> ListaDetalleDelPedido { get; set; }

        public string Comentario { get; set; }

        public string Estatus { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        public decimal Total { get; set; }
    }

    public class DireccionDtoIn
    {
        public string CalleYNumero { get; set; }

        public string Colonia { get; set; }

        public string CodigoPostal { get; set; }

        public string Referencia { get; set; }

        public string CoordenadasGps { get; set; }

        public string Alcaldia { get; set; }

        public string Estado { get; set; }
    }

    public class PlatilloDtoIn
    {
        //public string Nombre { get; set; }

        //public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public string Comentario { get; set; }

        [Required]
        public string Id { get; set; }
    }
}
