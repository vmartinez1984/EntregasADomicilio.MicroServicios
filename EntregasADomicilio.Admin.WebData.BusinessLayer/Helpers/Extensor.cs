using EntregasADomicilio.Admin.WebData.BusinessLayer.Bl;
using EntregasADomicilio.Admin.WebData.Core.Interfaces;
using EntregasADomicilio.Admin.WebData.Repositorio.Sql.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace EntregasADomicilio.Admin.WebData.BusinessLayer.Helpers
{
    public static class Extensor
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        { 
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRestauranteBl, RestauranteBl>();

            services.AddScoped<IRepositorio, RepositorioData>();
            services.AddScoped<IRestauranteRepositorio, RestauranteRepositorio>();
        }
    }
}