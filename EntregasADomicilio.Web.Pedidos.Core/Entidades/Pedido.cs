using Google.Cloud.Firestore;

namespace EntregasADomicilio.Web.Pedidos.Core.Entidades
{
    [FirestoreData]
    public class Pedido
    {
        [FirestoreProperty]
        public string Id { get; set; }
        

        [FirestoreProperty]
        public double Total { get; set; }
               
        [FirestoreProperty]
        public Cliente Cliente { get; set; }

        [FirestoreProperty]
        public string Comentario { get; set; }

        private DateTime fechaDeRegistro;

        [FirestoreProperty]
        public DateTime FechaDeRegistro
        {
            get { return fechaDeRegistro.ToUniversalTime(); }
            set { fechaDeRegistro = value; }
        }

        [FirestoreProperty]
        public string Estatus { get; set; }
               
        [FirestoreProperty]
        public List<Platillo> Platillos { get; set; }
    }
}
