using EntregasADomicilio.Admin.WebData.Core.Dtos.Web;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EntregasADomilicio.Web.Pedidos.Repositorios.Ws
{
    public class PedidoRepositorio
    {
        private readonly string _url;
        private readonly IHttpClientFactory _httpClientFactory;

        public PedidoRepositorio(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _url = configuration.GetSection("Pedidos").Value;
            _url += "pedidos/";
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IdDto> AgregarAsync(PedidoDtoIn pedido, int usuarioId)
        {
            IdDto idDto;
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;

            client = _httpClientFactory.CreateClient();
            request = new HttpRequestMessage(HttpMethod.Post, _url + usuarioId + "/pedidos");
            request.Content = new StringContent(JsonConvert.SerializeObject(pedido), null, "application/json");
            response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
                idDto = JsonConvert.DeserializeObject<IdDto>(await response.Content.ReadAsStringAsync());
            else
                throw new Exception("No se pudo agregar el pedido");

            return idDto;
        }

        public async Task<List<PedidoDto>> ObtenerTodosPorClienteIdAsync(int clienteId)
        {
            List<PedidoDto> pedidos;
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;

            client = _httpClientFactory.CreateClient();
            request = new HttpRequestMessage(HttpMethod.Get, _url + "clientes/" + clienteId);            
            response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
                pedidos = JsonConvert.DeserializeObject<List<PedidoDto>>(await response.Content.ReadAsStringAsync());
            else
                throw new Exception("No se pudo agregar el pedido");

            return pedidos;
        }

        public async Task<PedidoDto> ObtnerPorIdAsync(int pedidoId)
        {
            PedidoDto pedido;
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;

            client = _httpClientFactory.CreateClient();
            request = new HttpRequestMessage(HttpMethod.Get, _url + pedidoId);            
            response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
                pedido = JsonConvert.DeserializeObject<PedidoDto>(await response.Content.ReadAsStringAsync());
            else
                throw new Exception("No se pudo agregar el pedido");

            return pedido;
        }
    }
}
