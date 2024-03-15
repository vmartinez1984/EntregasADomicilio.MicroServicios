namespace EntregasADomicilio.Web.Pedidos.Core.Dtos
{
    public class ClienteDto
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public DireccionDto Direccion { get; set; }

        public DateTime FechaDeNacimiento { get; set; }
    }

    public class DireccionDto
    {
        public string CalleYNumero { get; set; }

        public string Referencia { get; set; }

        public string CoordenadasGps { get; set; }

        public string Colonia { get; set; }

        public string Alcaldia { get; set; }

        public string Estado { get; set; }

        public string CodigoPostal { get; set; }        
    }

}
