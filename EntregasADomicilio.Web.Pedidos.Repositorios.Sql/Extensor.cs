using Microsoft.Extensions.DependencyInjection;

namespace EntregasADomicilio.Web.Pedidos.Repositorios.Sql
{
    public static class Extensor
    {
        public static void AddRepositorio(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();

            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
        }
    }
}
