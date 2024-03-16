using EntregasADomicilio.Web.Platillos.Api.V2.Entities;
using EntregasADomicilio.Web.Platillos.Api.V2.Interfaces;
using Google.Cloud.Firestore;

namespace EntregasADomicilio.Web.Platillos.Api.V2.Repositorios
{
    public class TiendaRepositorio : ITienda
    {
        string ruta = "entregasadomicilio-7e116.json";
        string projectId;
        FirestoreDb _firestoreDb;
        string coleccion = "tienda";

        public TiendaRepositorio()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", ruta);
            projectId = "entregasadomicilio-7e116";
            _firestoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<Tienda> ObtenerAsync()
        {
            Query query;
            QuerySnapshot documentSnapshots;
            Tienda entidad = null;

            query = _firestoreDb.Collection(coleccion).Where(Filter.EqualTo(nameof(Tienda.EstaActivo), true));
            documentSnapshots = await query.GetSnapshotAsync();
            if (documentSnapshots.Count > 0)
            {
                entidad = documentSnapshots[0].ConvertTo<Tienda>();
            }

            return entidad;
        }
    }
}
