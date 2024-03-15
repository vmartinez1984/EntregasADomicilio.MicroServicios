using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Pedidos.Core.Dtos
{
    public class PlatilloDto
    {
        public Guid Id { get; set; }

        public string Categoria { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }
    }
}
