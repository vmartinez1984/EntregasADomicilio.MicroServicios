using Microsoft.Extensions.Configuration;
using System.Net.Http;
using EntregasADomicilio.Web.Pedidos.Core.Dtos;
using Newtonsoft.Json;

namespace EntregasADomicilio.Web.Pedidos.Platillos.Servicios
{
    public class PlatilloServicio
    {
        public readonly IHttpClientFactory _httpClientFactory;
        private readonly string _url;

        public PlatilloServicio(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _url = configuration["PlatillosServicio"] + "Platillos/";
        }

        public async Task<PlatilloDto> ObtenerPorId(string id)
        {
            PlatilloDto cliente;
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;
            // https://localhost:44395/api/Clientes/638e95d4-5243-4434-87e7-3b1b85747c09

            client = _httpClientFactory.CreateClient();
            request = new HttpRequestMessage(HttpMethod.Get, _url + id);
            response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                cliente = JsonConvert.DeserializeObject<PlatilloDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                cliente = null;
            }

            return cliente;
        }

        public async Task<PlatilloDto> ObtenerPorId(object id)
        {
            throw new NotImplementedException();
        }
    }
}
