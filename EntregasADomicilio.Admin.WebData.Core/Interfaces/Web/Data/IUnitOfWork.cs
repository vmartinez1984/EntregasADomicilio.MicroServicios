using EntregasADomicilio.Admin.WebData.Core.Dtos.Admin;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Data
{
    public interface IUnitOfWork
    {
        public IRestauranteBl Restaurante { get; set; }
    }

    public interface IRestauranteBl
    {
        Task AgregarAsync(RestauranteDto restaurante);
        Task<RestauranteDto> ObtenerAsync();
    }
}
