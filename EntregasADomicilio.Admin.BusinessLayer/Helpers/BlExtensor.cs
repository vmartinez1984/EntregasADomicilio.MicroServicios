using AutoMapper;
using EntregasADomicilio.Admin.BusinessLayer.Bl;
using EntregasADomicilio.Admin.Repositorio.Sql.Contexts;
using EntregasADomicilio.Admin.Repositorio.Sql.Entities;
using EntregasADomicilio.Admin.Repositorio.Sql.Interfaces;
using EntregasADomicilio.StoreFiles;
using Microsoft.Extensions.DependencyInjection;

namespace EntregasADomicilio.Admin.BusinessLayer.Helpers
{
    public static class BlExtensor
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();

            services.AddScoped<IRepositorySql, RepositorySql>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IDireccionRepository, DireccionRepository>();
            services.AddScoped<IPlatilloRepository, PlatilloRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            services.AddScoped<AlmacenDeArchivosFirebase>();

            services.AddScoped<UnitOfWorkBl>();

            services.AddScoped<CategoriaBl>();
            //services.AddScoped<IUsuarioBl, UsuarioBl>();
            //services.AddScoped<IClienteBl, ClienteBl>();
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
