using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasADomicilio.Usuarios.Core.Dtos
{
    public class TokenDto
    {
        public string Token { get; set; }

        public DateTime FechaDeExpiracion { get; set; }
    }
}
