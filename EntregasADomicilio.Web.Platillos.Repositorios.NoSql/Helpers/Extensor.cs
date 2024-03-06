using EntregasADomicilio.Web.Platillos.Core.Interfaces.Repositories;
using EntregasADomicilio.Web.Platillos.Repositorios.NoSql.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace EntregasADomicilio.Web.Platillos.Repositorios.NoSql.Helpers
{
    public static class RepositorioExtensor
    {
        public static void AddRepositorioNoSql(this IServiceCollection services)
        {
            services.AddScoped<IRepositorio, Repositorio>();
            services.AddScoped<IPlatillo, PlatilloRepositorio>();
            services.AddScoped<ICategoria, CategoriaRepositorio>();
        }
    }
}