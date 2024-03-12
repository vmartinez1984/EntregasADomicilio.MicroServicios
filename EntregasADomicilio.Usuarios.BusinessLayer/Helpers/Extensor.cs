using EntregasADomicilio.Usuarios.BusinessLayer.Bl;
using EntregasADomicilio.Usuarios.Core.Interfaces;
using EntregasADomicilio.Usuarios.Repositorios.FiresStore.Clientes;
using EntregasADomicilio.Usuarios.Repositorios.Firestore.Login;
using EntregasADomicilio.Usuarios.Repositorios.Firestore.Usuarios;
using JwtTokenService;
using Microsoft.Extensions.DependencyInjection;

namespace EntregasADomicilio.Usuarios.BusinessLayer.Helpers
{
    public static class Extensor
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<ClienteBl>();
            services.AddScoped<UnitOfWork>();

            services.AddScoped<JwtToken>();

            services.AddScoped<IInicioDeSesion, InicioDeSesionRepositorio>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        }
    }
}
