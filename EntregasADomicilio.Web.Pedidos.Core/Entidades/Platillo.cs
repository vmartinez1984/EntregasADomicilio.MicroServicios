using Google.Cloud.Firestore;

namespace EntregasADomicilio.Web.Pedidos.Core.Entidades
{
    [FirestoreData]
    public class Platillo
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Nombre { get; set; }

        [FirestoreProperty]
        public string Descripcion { get; set; }

        [FirestoreProperty]
        public double Precio { get; set; }

        [FirestoreProperty]
        public string Comentario { get; set; }
    }
}
