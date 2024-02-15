using AutoMapper;
using EntregasADomicilio.Admin.WebData.Core.Dtos.Web;
using EntregasADomicilio.Admin.WebData.Core.Entities;
using EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Usuarios;

namespace EntregasADomicilio.Web.Usuarios.BusinessLayer.Bl
{
    public class ClienteBl : IClienteBl
    {
        private readonly IRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly IUsuarioBl _usuarioBl;

        public ClienteBl(IRepositorio repositorio, IMapper mapper, IUsuarioBl usuarioBl)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _usuarioBl = usuarioBl;
        }

        public async Task ActualizarDireccionAsync(int direccionId, DireccionDtoIn direccion)
        {
            Direccion entity;

            entity = await _repositorio.Direccion.ObtenerPorId(direccionId);
            entity = _mapper.Map(direccion, entity);

            await _repositorio.Direccion.Actualizar(entity);
        }

        public async Task<int> AgregarAsync(ClienteDtoIn clienteDtoIn)
        {
            string identityId;
            int id;

            identityId = await _usuarioBl.AgregarAsync(new UsuarioDtoIn { Correo = clienteDtoIn.Correo, Contrasenia = clienteDtoIn.Contrasenia, Role = "Cliente" });
            id = await AgregarClienteYDireccion(identityId, clienteDtoIn);

            return id; 
        }

        private async Task<int> AgregarClienteYDireccion(string identityId, ClienteDtoIn cliente)
        {
            Cliente clienteEntity;

            clienteEntity = _mapper.Map<Cliente>(cliente);
            clienteEntity.UsuarioId = identityId;
            clienteEntity.Direcciones = new List<Direccion> {
                    _mapper.Map<Direccion>(cliente.Direccion)
                };
            await _repositorio.Cliente.AgregarAsync(clienteEntity);

            return clienteEntity.Id;
        }

        public async Task<int> AgregarDireccionAsync(int clienteId, DireccionDtoIn direccion)
        {
            Direccion entity;

            entity = _mapper.Map<Direccion>(direccion);
            entity.UsuarioId = clienteId;
            await _repositorio.Direccion.AgregarAsync(entity);

            return entity.Id;
        }

        public Task ColocarComoPrincipalAsync(int direccionId, int clienteId)
        {
            throw new NotImplementedException();
        }

        public async Task<ClienteDto> ObtenerPorIdAsync(int clienteId)
        {
            Cliente cliente;
            ClienteDto clienteDto;

            cliente = await _repositorio.Cliente.ObtenerPorIdAsync(clienteId);
            clienteDto = _mapper.Map<ClienteDto>(cliente);

            return clienteDto;
        }
    }
}
