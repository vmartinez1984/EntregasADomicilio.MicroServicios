using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using EntregasADomicilio.Web.Platillos.BusinessLayer.Bl;
using EntregasADomicilio.Web.Platillos.BusinessLayer.Interfaces;
using EntregasADomicilio.Web.Platillos.Core.Interfaces.Repositories;
using EntregasADomicilio.Web.Platillos.Repositorios.FireStore.Repositorios;
using EntregasADomicilio.StoreFiles;

namespace EntregasADomicilio.Web.Platillos.BusinessLayer.Helpers
{
    public static class RepositorioExtensor
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            //services.AddRepositorioSql();
            //services.AddRepositorioNoSql();
            services.AddScoped<IRepositorio, Repositorio>();
            services.AddScoped<IPlatillo, PlatilloRepositorio>();
            services.AddScoped<ICategoria, CategoriaRepositorio>();

            services.AddScoped<AlmacenDeArchivosFirebase>();

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
