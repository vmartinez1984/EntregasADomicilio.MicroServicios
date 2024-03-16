using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using EntregasADomicilio.Web.Pedidos.Servicios.Ws;
using EntregasADomicilio.Web.Pedidos.Repositorios.Firestore;
using EntregasADomicilio.Web.Pedidos.Core.Interfaces;
using JwtTokenService;

namespace EntregasADomicilio.Web.Pedidos.BusinessLayer
{
    public static class Extensor
    {
        public static void AddPedidos(this IServiceCollection services)
        {
            //services.AddRepositorio();
            services.AddScoped<IPedidoRepositorio,PedidoRepositorio>();

            services.AddScoped<IPedidoBl, PedidoBl>();
            services.AddScoped<ClienteServicio>();
            services.AddScoped<PlatilloServicio>();

            //Mappers
            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile<Mappers>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //factory
            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
            };

            services.AddHttpClient("ignoreSSL", c =>
            { }).ConfigurePrimaryHttpMessageHandler(h => httpClientHandler);
        }
    }
}