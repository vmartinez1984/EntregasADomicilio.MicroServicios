using Microsoft.Extensions.DependencyInjection;
using EntregasADomicilio.Web.Pedidos.Repositorios.Sql;
using AutoMapper;

namespace EntregasADomicilio.Web.Pedidos.BusinessLayer
{
    public static class Extensor
    {
        public static void AddPedidos(this IServiceCollection services)
        {
            services.AddRepositorio();

            services.AddScoped<IPedidoBl, PedidoBl>();

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