using EntregasADomicilio.Usuarios.Core.Entities;
using EntregasADomicilio.Usuarios.Core.Interfaces;
using Google.Cloud.Firestore;

namespace EntregasADomicilio.Usuarios.Repositorios.Firestore.Login
{
    public class InicioDeSesionRepositorio : IInicioDeSesion
    {
        string ruta = "entregasadomicilio-7e116.json";
        string projectId;
        FirestoreDb _firestoreDb;
        string coleccion = "inicioDeSesiones";

        public InicioDeSesionRepositorio()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", ruta);
            projectId = "entregasadomicilio-7e116";
            _firestoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<string> AgregarInicioSesionAsync(InicioDeSesion entity)
        {
            CollectionReference collectionReference = _firestoreDb.Collection(coleccion);
            await collectionReference.AddAsync(entity);

            return entity.Id;
        }

        public async Task<string> IniciarSesionAsync(string correo, string contrasenia)
        {            
            Query query;
            QuerySnapshot documentSnapshots;
            InicioDeSesion entity = null;

            query = _firestoreDb.Collection(coleccion)
                .Where(Filter.EqualTo(nameof(InicioDeSesion.Correo), correo))
                .Where(Filter.EqualTo(nameof(InicioDeSesion.Contrasenia), contrasenia));
            documentSnapshots = await query.GetSnapshotAsync();
            if (documentSnapshots.Count > 0)
            {
                entity = documentSnapshots[0].ConvertTo<InicioDeSesion>();
            }

            return entity is null ? string.Empty: entity.Id;

        }
    }
}
