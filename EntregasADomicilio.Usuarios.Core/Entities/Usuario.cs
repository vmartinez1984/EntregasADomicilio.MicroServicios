using Google.Cloud.Firestore;

namespace EntregasADomicilio.Usuarios.Core.Entities
{
    [FirestoreData]
    public class Usuario
    {
        [FirestoreProperty]
        public string Apellidos { get; set; }

        [FirestoreProperty]
        public string Nombre { get; set; }

        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string InicioDeSesiónId { get; set; }

        [FirestoreProperty]
        public List<string> Roles { get; set; }

    }
}
