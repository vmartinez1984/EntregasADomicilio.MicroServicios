using Google.Cloud.Firestore;

namespace EntregasADomicilio.Usuarios.Core.Entities
{
    [FirestoreData]
    public class InicioDeSesion
    {
        [FirestoreProperty]
        public string Contrasenia { get; set; }

        [FirestoreProperty]
        public string Correo { get; set; }

        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Nombre { get; set; }

        [FirestoreProperty]
        public bool EstaActivo { get; set; }
    }
}
