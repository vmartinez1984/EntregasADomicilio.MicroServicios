namespace EntregasADomicilio.Web.Platillos.Api.V2.Dtos
{
    public class TiendaDto
    {
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string CoordenadasGps { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public List<HorarioDto> Horarios { get; set; }

        public List<TarjetaDto> Tarjetas { get; set; }

        public AcercaDeNosotrosDto AcercaDeNosotros { get; set; }
    }
    public class TarjetaDto
    {
        public string Icon { get; set; }

        public string Titulo { get; set; }

        public string Contenido { get; set; }
    }

    public class HorarioDto
    {
        public string Dias { get; set; }
        public string Horas { get; set; }
    }
    public class AcercaDeNosotrosDto
    {
        public string Titulo { get; set; }

        public string Contenido { get; set; }
    }
}
