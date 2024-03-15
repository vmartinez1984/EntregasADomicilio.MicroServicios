using EntregasADomicilio.Web.Pedidos.Core.Dtos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EntregasADomicilio.Web.Pedidos.Clientes.Servicios
{
    public class ClienteServicio
    {
        public readonly IHttpClientFactory _httpClientFactory;
        private readonly string _url;

        public ClienteServicio(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _url = configuration["UsuariosServicio"] + "Clientes/";
        }

        public async Task<ClienteDto> ObtenerCliente(string clienteId)
        {
            ClienteDto cliente;
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;
            // https://localhost:44395/api/Clientes/638e95d4-5243-4434-87e7-3b1b85747c09

            client = _httpClientFactory.CreateClient();
            request = new HttpRequestMessage(HttpMethod.Get, _url + clienteId);
            response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                cliente = JsonConvert.DeserializeObject<ClienteDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                cliente = null;
            }

            return cliente;
        }
    }
}
