using EntregasADomicilio.Usuarios.Core.Entities;

namespace EntregasADomicilio.Usuarios.Core.Interfaces
{
    public interface IInicioDeSesion
    {
        Task<string> IniciarSesionAsync(string correo, string contrasenia);

        Task<string> AgregarInicioSesionAsync(InicioDeSesion inicioDeSesion);
    }
}
