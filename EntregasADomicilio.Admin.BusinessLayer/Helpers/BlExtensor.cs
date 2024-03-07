using AutoMapper;
using EntregasADomicilio.Admin.BusinessLayer.Bl;
using EntregasADomicilio.Admin.Platillos.Core.Interfaces;
using EntregasADomicilio.Admin.Platillos.FireStore.Repositorios;
using EntregasADomicilio.StoreFiles;
using Microsoft.Extensions.DependencyInjection;

namespace EntregasADomicilio.Admin.BusinessLayer.Helpers
{
    public static class BlExtensor
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            //services.AddScoped<AppDbContext>();

            services.AddScoped<IRepositorio, Repositorio>();

            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IPlatilloRepositorio, PlatilloRepositorio>();            

            services.AddScoped<AlmacenDeArchivosFirebase>();

            services.AddScoped<UnitOfWorkBl>();

            services.AddScoped<CategoriaBl>();
            services.AddScoped<PlatilloBl>();

            //Mappers
            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile<EntregasADomicilioMappers>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
