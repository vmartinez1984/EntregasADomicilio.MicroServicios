using EntregasADomicilio.Admin.WebData.Core.Dtos.Admin;
using EntregasADomicilio.Admin.WebData.Core.Entities;
using EntregasADomicilio.Admin.WebData.Core.Interfaces;

namespace EntregasADomicilio.Admin.WebData.BusinessLayer.Bl
{
    public class RestauranteBl : IRestauranteBl
    {
        private readonly IRepositorio _repositorio;

        public RestauranteBl(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task AgregarAsync(RestauranteDto restaurante)
        {
            await _repositorio.Restaurante.AgregarAsync(new Restaurante { 
                CalleYNumero = restaurante.CalleYNumero,
                CodigoPostal = restaurante.CodigoPostal,
                Colonia = restaurante.Colonia,
                Estado = restaurante.Estado,
                Latitud = restaurante.Latitud,
                Longitud = restaurante.Longitud,
                Nombre = restaurante.Nombre,
                Slogan = restaurante.Slogan
            });
        }

        public async Task<RestauranteDto> ObtenerAsync()
        {
            RestauranteDto restauranteDto;
            Restaurante restaurante;

            restaurante = await _repositorio.Restaurante.Obtener();
            restauranteDto = new RestauranteDto
            {
                CalleYNumero = restaurante.CalleYNumero,
                CodigoPostal = restaurante.CodigoPostal,
                Colonia = restaurante.Colonia,
                Estado = restaurante.Estado,
                Latitud = restaurante.Latitud,
                Longitud = restaurante.Longitud,
                Nombre = restaurante.Nombre,
                Slogan = restaurante.Slogan
            };

            return restauranteDto;
        }
    }
}
