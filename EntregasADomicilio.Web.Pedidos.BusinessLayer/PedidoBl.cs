using AutoMapper;
using EntregasADomicilio.Core.Constants;
using EntregasADomicilio.Core.Entities;
using EntregasADomicilio.Web.Pedidos.Repositorios.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EntregasADomicilio.Web.Pedidos.BusinessLayer
{
    public class PedidoBl : IPedidoBl
    {
        public readonly IPedidoRepositorio _repositorySql;
        public readonly IMapper _mapper;

        public PedidoBl(IPedidoRepositorio repositorySql, IMapper mapper)
        {
            _repositorySql = repositorySql;
            _mapper = mapper;
        }

        public async Task<int> AgregarAsync(PedidoDtoIn pedidoDto, int clienteId)
        {
            Pedido pedido;

            pedido = new Pedido
            {
                ClienteId = clienteId,
                Comentario = pedidoDto.Comentario,
                Estatus = EstatusDelPedido.PedidoRealizado,
                ListaDetalleDelPedido = ObtenerListaDeDetalleDelPedido(pedidoDto.ListaDetalleDelPedido),
                Total = pedidoDto.ListaDetalleDelPedido.Sum(x => x.Precio), 
                FechaDeRegistro = DateTime.Now,
                Guid = pedidoDto.Guid
            };

            await _repositorySql.AgregarAsync(pedido);

            return pedido.Id;
        }

        private List<DetalleDelPedido> ObtenerListaDeDetalleDelPedido(List<PlatilloDtoIn> listaDetalleDelPedido)
        {
            List<DetalleDelPedido> lista;

            lista = new List<DetalleDelPedido>();
            foreach (var item in listaDetalleDelPedido)
            {
                lista.Add(new DetalleDelPedido
                {
                    PlatilloId = item.PlatilloId,
                    Precio = item.Precio
                });
            }

            return lista;
        }

        public async Task<PedidoDto> ObtenerAsync(int pedidoId)
        {
            Pedido pedido;
            PedidoDto pedidoDto;

            pedido = await _repositorySql.ObtenerPorIdAsync(pedidoId);
            pedidoDto = _mapper.Map<PedidoDto>(pedido);

            return pedidoDto;
        }

        public async Task<List<PedidoDto>> ObtenerTodosPorClienteIdAsync(int clienteID)
        {
            List<PedidoDto> pedidosDtos;
            List<Pedido> pedidos;

            pedidos = await _repositorySql.ObtenerTodosPorClienteIdAsync(clienteID);
            pedidosDtos = _mapper.Map<List<PedidoDto>>(pedidos);

            return pedidosDtos;
        }
    }
}
