using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Pedidos.Core.Dtos
{
    public class PedidoDtoIn
    {
        public Guid Id { get; set; }

        public decimal Total { get; set; }

        public string Estado { get; set; }

        public string Cliente { get; set; }
        public string ClienteId { get; set; }

        public DireccionDto Direccion { get; set; }

        public List<PlatilloDto> Platillos { get; set; }
    }

    public class DireccionDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string CalleYNumero { get; set; }

        public string Colonia { get; set; }

        public string CodigoPostal { get; set; }

        public string Referencia { get; set; }

        public string CoordenadasGps { get; set; }

        public string Alcaldia { get; set; }

        public string Estado { get; set; }
    }

    public class PlatilloDto
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Precio { get; set; }

        public string Comentario { get; set; }
    }
}
