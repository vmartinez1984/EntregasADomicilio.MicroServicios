using Google.Cloud.Firestore;

namespace EntregasADomicilio.Admin.Platillos.Core.Entidades
{
    [FirestoreData]
    public class Categoria
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Nombre { get; set; }

        [FirestoreProperty]
        public bool EstaActivo { get; set; }
    }
}
