using EntregasADomicilio.Web.Platillos.Api.V2.Interfaces;
using EntregasADomicilio.Web.Platillos.Api.V2.Entities;
using Google.Cloud.Firestore;

namespace EntregasADomicilio.Web.Platillos.Api.V2.Repositorios
{
    public class CategoriaRepositorio : ICategoria
    {
        string ruta = "entregasadomicilio-7e116.json";
        string projectId;
        FirestoreDb _firestoreDb;
        string coleccion = "categorias";

        public CategoriaRepositorio()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", ruta);
            projectId = "entregasadomicilio-7e116";
            _firestoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<List<Categoria>> ObtenerTodosAsync()
        {
            Query query = _firestoreDb.Collection(coleccion).Where(Filter.EqualTo("EstaActivo", true));
            QuerySnapshot documentSnapshots = await query.GetSnapshotAsync();
            List<Categoria> lista = new List<Categoria>();            
            lista = documentSnapshots.Select(x=> x.ConvertTo<Categoria>()).ToList();

            return lista;
        }
    }
}
