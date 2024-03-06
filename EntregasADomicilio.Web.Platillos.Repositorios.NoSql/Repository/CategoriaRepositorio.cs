using EntregasADomicilio.Web.Platillos.Core.Entities;
using EntregasADomicilio.Web.Platillos.Core.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EntregasADomicilio.Web.Platillos.Repositorios.NoSql.Repository
{
    public class CategoriaRepositorio : ICategoria
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<Categoria> _collection;

        public CategoriaRepositorio(IConfiguration configuration)
        {
            string connectionString = "mongodb://root:123456@localhost:27017/";
            string dataBaseName = "enregas-a-domicilio";
            string collectionName = "categorias";

            var mongoClient = new MongoClient(connectionString);

            _mongoDatabase = mongoClient.GetDatabase(dataBaseName);

            _collection = _mongoDatabase.GetCollection<Categoria>(collectionName);
        }

        public async Task<List<Categoria>> ObtenerTodosAsync()
        {
            List<Categoria> categorias;

            categorias = await _collection.Find(x => x.EstaActivo == true).ToListAsync();

            return categorias;
        }
    }
}
