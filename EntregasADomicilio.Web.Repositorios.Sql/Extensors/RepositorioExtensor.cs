using EntregasADomicilio.Web.Repositorios.Sql.Contexts;
using EntregasADomicilio.Web.Repositorios.Sql.Interfaces;
using EntregasADomicilio.Web.Repositorios.Sql.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace EntregasADomicilio.Web.Repositorios.Sql.Extensors
{
    public static class RepositorioExtensor
    {
        public static void AddRepositorySql(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();

            services.AddScoped<IRepositorio, Repositorio>();
            services.AddScoped<IPlatillo, PlatilloRepositorio>();
            services.AddScoped<ICategoria, CategoriaRepositorio>();
        }
    }
}