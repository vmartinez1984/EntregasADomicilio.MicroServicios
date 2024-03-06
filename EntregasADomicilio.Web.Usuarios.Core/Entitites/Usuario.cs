namespace EntregasADomicilio.Web.Usuarios.Core.Entitites
{
    public class UsuarioEntity
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        //public string Apellidos { get; set; }

        public string Correo { get; set; }

        //public DateTime FechaDeNacimiento { get; set; }

        public bool EstaActivo { get; set; }

        public List<Role> Roles { get; set; }
    }

    public class Role
    {
        public string Id { get; set;}

        public string Nombre { get; set; }

        public bool EstaActivo { get; set; }
    }
}
