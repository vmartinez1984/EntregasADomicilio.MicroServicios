using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasADomicilio.Usuarios.Core.Dtos
{
    public class UsuarioDtoIn
    {
        public Guid Id { get; set; }
        public string Contrasenia { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }

        public ClienteDtoIn Cliente { get; set; }
    }

    public class ClienteDtoIn
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }

        public DireccionDtoIn Direccion { get; set; }
    }

    public class DireccionDtoIn
    {
        public string CalleYNumero { get; set; }
        public string Alcaldia { get; set; }
        public string CodigoPostal { get; set; }
        public string Colonia { get; set; }
        public string CoordenadasGps { get; set; }
        public bool EsLaPrincipal { get; set; }
        public string Estado { get; set; }
        public string Referencia { get; set; }
    }
}
