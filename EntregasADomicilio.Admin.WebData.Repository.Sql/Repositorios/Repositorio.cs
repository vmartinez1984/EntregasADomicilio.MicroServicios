using EntregasADomicilio.Admin.WebData.Core.Entities;
using EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Data;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.WebData.Repositorio.Sql.Repositorios
{
    public class RepositorioData : IRepositorio
    {     

        public RepositorioData(IRestauranteRepositorio restauranteRepositorio)
        {
            Restaurante = restauranteRepositorio;
        }

        public IRestauranteRepositorio Restaurante {get; set;}
    }

    public class RestauranteRepositorio : IRestauranteRepositorio
    {
        public async Task<Restaurante> Obtener()
        {
            Restaurante restaurante;

            var data = await File.ReadAllTextAsync("Repositorio.txt");
            restaurante = JsonConvert.DeserializeObject<Restaurante>(data);

            return restaurante;
        }

        public async Task AgregarAsync(Restaurante restaurante)
        {
            await File.WriteAllTextAsync("Repositorio.txt", JsonConvert.SerializeObject(restaurante, Formatting.Indented));
        }
    }
}
