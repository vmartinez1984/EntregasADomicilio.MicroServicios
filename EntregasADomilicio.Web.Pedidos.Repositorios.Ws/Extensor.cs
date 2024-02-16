using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace EntregasADomilicio.Web.Pedidos.Repositorios.Ws
{
    public static class Extensor
    {
        public static void AddPedidoRepositorio(this IServiceCollection services)
        {
            services.AddScoped<PedidoRepositorio>();

            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
            };
            services.AddHttpClient("ignoreSSL", c => { }).ConfigurePrimaryHttpMessageHandler(h => httpClientHandler);
        }
    }
}