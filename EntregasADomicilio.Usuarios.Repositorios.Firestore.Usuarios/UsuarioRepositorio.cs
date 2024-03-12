using EntregasADomicilio.Usuarios.Core.Entities;
using EntregasADomicilio.Usuarios.Core.Interfaces;
using Google.Cloud.Firestore;

namespace EntregasADomicilio.Usuarios.Repositorios.Firestore.Usuarios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        string ruta = ".\\entregasadomicilio-7e116.json";
        string projectId;
        FirestoreDb _firestoreDb;
        string coleccion = "usuarios";

        public UsuarioRepositorio()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", ruta);
            projectId = "entregasadomicilio-7e116";
            _firestoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<string> AgregarAsync(Usuario entity)
        {
            CollectionReference collectionReference = _firestoreDb.Collection(coleccion);
            await collectionReference.AddAsync(entity);

            return entity.Id;
        }

        public async Task<Usuario> ObtenerPorInicioDeSesionId(string id)
        {
            Query query;
            QuerySnapshot documentSnapshots;
            Usuario entity = null;

            query = _firestoreDb.Collection(coleccion).Where(Filter.EqualTo(nameof(Usuario.Id), id));
            documentSnapshots = await query.GetSnapshotAsync();
            if (documentSnapshots.Count > 0)
            {
                entity = documentSnapshots[0].ConvertTo<Usuario>();
            }

            return entity;
        }
    }
}
