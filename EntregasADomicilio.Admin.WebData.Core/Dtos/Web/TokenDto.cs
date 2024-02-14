using System;

namespace EntregasADomicilio.Admin.WebData.Core.Dtos.Web
{
    public class TokenDto
    {
        public string Token { get; set; }

        public DateTime Expiracion { get; set; }
    }
}
