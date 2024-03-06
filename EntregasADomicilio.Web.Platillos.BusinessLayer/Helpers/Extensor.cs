using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using EntregasADomicilio.Web.Platillos.Repositorios.NoSql.Helpers;
using EntregasADomicilio.Web.Platillos.Repositorios.Sql.Helpers;
using EntregasADomicilio.Web.Platillos.BusinessLayer.Bl;
using EntregasADomicilio.Web.Platillos.BusinessLayer.Interfaces;

namespace EntregasADomicilio.Web.Platillos.BusinessLayer.Helpers
{
    public static class RepositorioExtensor
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddRepositorioSql();
            services.AddRepositorioNoSql();

            services.AddScoped<IUnitOfWorkBl, UnitOfWork>();
            services.AddScoped<ICategoriaBl, CategoriaBl>();
            services.AddScoped<IPlatilloBl, PlatilloBl>();

            //Mappers
            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile<Mappers>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
