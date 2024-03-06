using System;

namespace EntregasADomicilio.Admin.WebData.Core.Dtos.Web
{
    public class TokenDto
    {

        public TokenDto(string tokenString, DateTime dateTime)
        {
            this.Token = tokenString;
            this.Expiracion = dateTime;
        }

        public string Token { get; set; }

        public DateTime Expiracion { get; set; }
    }
}
