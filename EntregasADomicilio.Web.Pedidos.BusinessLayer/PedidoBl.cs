using AutoMapper;
using EntregasADomicilio.Web.Pedidos.Servicios.Ws;
using EntregasADomicilio.Web.Pedidos.Core.Interfaces;
using EntregasADomicilio.Web.Pedidos.Core.Entidades;
using EntregasADomicilio.Web.Pedidos.Core.Dtos;
using EntregasADomicilio.Web.Pedidos.Core.Constantes;


namespace EntregasADomicilio.Web.Pedidos.BusinessLayer
{
    public class PedidoBl : IPedidoBl
    {
        public readonly IPedidoRepositorio _repositorySql;
        public readonly IMapper _mapper;
        private readonly ClienteServicio _clienteServicio;
        private readonly PlatilloServicio _platilloServicio;

        public PedidoBl(
            IPedidoRepositorio repositorySql,
            IMapper mapper,
            ClienteServicio clienteServicio,
            PlatilloServicio platilloServicio
        )
        {
            _repositorySql = repositorySql;
            _mapper = mapper;
            _clienteServicio = clienteServicio;
            _platilloServicio = platilloServicio;
        }

        public async Task<string> AgregarAsync(PedidoDtoIn pedidoDto, string clienteId)
        {
            ClienteDto cliente;
            Pedido pedido;

            cliente = await _clienteServicio.ObtenerCliente(clienteId);
            pedido = new Pedido
            {
                Cliente = new Cliente
                {
                    Id = clienteId,
                    Apellidos = cliente.Apellidos,
                    Correo = cliente.Correo,
                    Nombre = cliente.Nombre,
                    Telefono = cliente.Telefono,
                    //FechaDeNacimiento = cliente.FechaDeNacimiento,
                    Direccion = new Direccion
                    {
                        Alcaldia = cliente.Direccion.Alcaldia,
                        CalleYNumero = cliente.Direccion.CalleYNumero,
                        CodigoPostal = cliente.Direccion.CodigoPostal,
                        Estado = cliente.Direccion.Estado,
                        Referencias = cliente.Direccion.Referencia,
                        CoordenadasGps = cliente.Direccion.CoordenadasGps
                    }
                },
                Comentario = pedidoDto.Comentario,
                Estatus = EstatusDelPedido.PedidoRealizado,
                FechaDeRegistro = System.DateTime.Now,
                Id = pedidoDto.Id.ToString(),
                Platillos = await ObtenerPlatillos(pedidoDto.Platillos),
                Total = (double)pedidoDto.Platillos.Sum(x => x.Precio)
            };
            await _repositorySql.AgregarAsync(pedido);

            return pedido.Id;
        }

        private async Task<List<Platillo>> ObtenerPlatillos(List<PlatilloDtoIn> listaDetalleDelPedido)
        {
            List<Platillo> platillos;

            platillos = new List<Platillo>();
            foreach (var item in listaDetalleDelPedido)
            {
                PlatilloDto platillo;

                platillo = await _platilloServicio.ObtenerPorId(item.Id);

                platillos.Add(new Platillo
                {
                    Id = platillo.Id.ToString(),
                    Nombre = platillo.Nombre,
                    Descripcion = platillo.Descripcion,
                    Precio = (double)item.Precio
                }); ;
            }

            return platillos;
        }

        public async Task<PedidoDto> ObtenerAsync(string pedidoId)
        {
            Pedido pedido;
            PedidoDto pedidoDto;

            pedido = await _repositorySql.ObtenerPorIdAsync(pedidoId);
            pedidoDto = _mapper.Map<PedidoDto>(pedido);

            return pedidoDto;
        }

        public async Task<List<PedidoDto>> ObtenerTodosPorClienteIdAsync(string clienteID)
        {
            List<PedidoDto> pedidosDtos;
            List<Pedido> pedidos;

            pedidos = await _repositorySql.ObtenerTodosPorClienteIdAsync(clienteID);
            pedidosDtos = _mapper.Map<List<PedidoDto>>(pedidos);

            return pedidosDtos;
        }
    }
}
