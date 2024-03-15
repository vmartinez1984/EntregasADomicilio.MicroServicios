using EntregasADomicilio.Usuarios.Core.Dtos;
using EntregasADomicilio.Usuarios.Core.Entities;
using EntregasADomicilio.Usuarios.Core.Interfaces;
using JwtTokenService;

namespace EntregasADomicilio.Usuarios.BusinessLayer.Bl
{
    public class ClienteBl
    {
        private readonly IInicioDeSesion _inicioDeSesion;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly JwtToken _jwtToken;

        public ClienteBl(
            IInicioDeSesion inicioDeSesion,
            IClienteRepositorio clienteRepositorio,
            IUsuarioRepositorio usuarioRepositorio,
            JwtToken jwtToken
        )
        {
            _inicioDeSesion = inicioDeSesion;
            _clienteRepositorio = clienteRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _jwtToken = jwtToken;
        }

        public async Task AgregarAsync(UsuarioDtoIn usuario)
        {
            if (usuario.Id == Guid.Empty)
                usuario.Id = Guid.NewGuid();
            await _inicioDeSesion.AgregarInicioSesionAsync(new InicioDeSesion
            {
                Contrasenia = usuario.Contrasenia,
                Correo = usuario.Correo,
                EstaActivo = true,
                Id = usuario.Id.ToString(),
                Nombre = usuario.Nombre
            });
            await _clienteRepositorio.AgregarAsync(new Cliente
            {
                Nombre = usuario.Cliente.Nombre,
                Apellidos = usuario.Cliente.Apellidos,
                Correo = usuario.Correo,
                Id = usuario.Id.ToString(),
                Telefono = usuario.Cliente.Telefono,
                UsuarioId = usuario.Id.ToString(),
                Direcciones = new List<Direccion>{ new Direccion{
                        CalleYNumero = usuario.Cliente.Direccion.CalleYNumero,
                        Alcaldia = usuario.Cliente.Direccion.Alcaldia,
                        CodigoPostal = usuario.Cliente.Direccion.CodigoPostal,
                        Colonia = usuario.Cliente.Direccion.Colonia,
                        CoordenadasGps = usuario.Cliente.Direccion.CoordenadasGps,
                        EsLaPrincipal = usuario.Cliente.Direccion.EsLaPrincipal,
                        Estado = usuario.Cliente.Direccion.Estado,
                        Id = Guid.NewGuid().ToString(),
                        Referencia = usuario.Cliente.Direccion.Referencia
                    }
                }
            });
            await _usuarioRepositorio.AgregarAsync(new Usuario
            {
                Apellidos = usuario.Cliente.Apellidos,
                InicioDeSesiónId = usuario.Id.ToString(),
                Id = usuario.Id.ToString(),
                Nombre = usuario.Nombre,
                Roles = new List<string> { "Cliente" }
            });
        }

        public async Task<TokenDto> IniciarSesionAsync(InicioDeSesionDto inicioDeSesion)
        {
            string id;
            string token;
            Usuario usuario;
            DateTime fechaDeExpiracion = DateTime.Now.AddMinutes(20);

            id = await _inicioDeSesion.IniciarSesionAsync(inicioDeSesion.Correo, inicioDeSesion.Contrasenia);
            if (string.IsNullOrEmpty(id))
                return null;
            usuario = await _usuarioRepositorio.ObtenerPorInicioDeSesionId(id);
            token = _jwtToken.ObtenerToken(
                usuario.Nombre + usuario.Apellidos,
                usuario.Id.ToString(),
                usuario.Roles[0],
                inicioDeSesion.Correo,
                fechaDeExpiracion
            );

            return new TokenDto
            {
                Token = token,
                FechaDeExpiracion = fechaDeExpiracion
            };
        }

        public async Task<ClienteDto> ObtenerAsync(Guid clienteId)
        {
            Cliente cliente;
            ClienteDto clienteDto;

            cliente = await _clienteRepositorio.ObtenerPorIdAsync(clienteId.ToString());
            if(cliente == null) 
                return null;
            clienteDto = new ClienteDto
            {
                Apellidos = cliente.Apellidos,
                Correo = cliente.Correo,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono,
                Id = Guid.Parse(cliente.Id),
                Direccion = ObtenerDireccion(cliente)
            };

            return clienteDto;
        }

        private DireccionDto ObtenerDireccion(Cliente cliente)
        {
            Direccion direccion;

            direccion = cliente.Direcciones.Where(x=> x.EsLaPrincipal == true).FirstOrDefault();

            return new DireccionDto
            {
                Alcaldia = direccion.Alcaldia,
                CalleYNumero = direccion.CalleYNumero,
                Colonia = direccion.Colonia,
                CoordenadasGps = direccion.CoordenadasGps,
                Estado = direccion.Estado,
                Referencia = direccion.Referencia
            };
        }
    }
}
