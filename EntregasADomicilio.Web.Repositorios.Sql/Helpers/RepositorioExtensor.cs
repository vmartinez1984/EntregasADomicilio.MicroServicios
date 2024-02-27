using EntregasADomicilio.Web.Platillos.Core.Interfaces.Repositories;
using EntregasADomicilio.Web.Platillos.Repositorios.Sql.Repository;
using EntregasADomicilio.Web.Platillos.Repositorios.Sql.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace EntregasADomicilio.Web.Platillos.Repositorios.Sql.Helpers
{
    public static class RepositorioExtensor
    {
        public static void AddRepositorioSql(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<IRepositorio, Repositorio>();
            services.AddScoped<IPlatillo, PlatilloRepositorio>();
            services.AddScoped<ICategoria, CategoriaRepositorio>();
        }
    }
}