using System;

namespace EntregasADomicilio.Web.Platillos.Api.V2.Dtos
{
    public class PlatilloDto
    {
        public string Id { get; set; }

        public string Categoria { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }
    }
}
