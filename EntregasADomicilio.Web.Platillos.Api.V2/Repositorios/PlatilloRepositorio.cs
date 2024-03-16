using EntregasADomicilio.Web.Platillos.Api.V2.Interfaces;
using EntregasADomicilio.Web.Platillos.Api.V2.Entities;
using Google.Cloud.Firestore;

namespace EntregasADomicilio.Web.Platillos.Api.V2.Repositorios
{
    public class PlatilloRepositorio : IPlatillo
    {
        string ruta = "entregasadomicilio-7e116.json";
        string projectId;
        FirestoreDb _firestoreDb;
        string coleccion = "platillos";

        public PlatilloRepositorio()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", ruta);
            projectId = "entregasadomicilio-7e116";
            _firestoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<Platillo> ObtenerPorIdAsync(string platilloId)
        {
            Query query;
            QuerySnapshot documentSnapshots;
            Platillo platillo = null;

            query = _firestoreDb.Collection(coleccion).Where(Filter.EqualTo(nameof(Platillo.Id), platilloId));
            documentSnapshots = await query.GetSnapshotAsync();
            if (documentSnapshots.Count > 0)
            {
                platillo = documentSnapshots[0].ConvertTo<Platillo>();
            }

            return platillo;
        }

        public async Task<List<Platillo>> ObtenerTodosAsync()
        {
            Query query;
            List<Platillo> lista;
            QuerySnapshot documentSnapshots; 

            query = _firestoreDb.Collection(coleccion).Where(Filter.EqualTo("EstaActivo", true));
            documentSnapshots = await query.GetSnapshotAsync();            
            lista = documentSnapshots.Select(x => x.ConvertTo<Platillo>()).ToList();

            return lista;
        }

    }
}