using EntregasADomicilio.Admin.WebData.Core.Entities;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Data
{
    public interface IRepositorio
    {
        public IRestauranteRepositorio Restaurante { get; set; }
    }

    public interface IRestauranteRepositorio
    {
        Task AgregarAsync(Restaurante restaurante);

        Task<Restaurante> Obtener();
    }
}
