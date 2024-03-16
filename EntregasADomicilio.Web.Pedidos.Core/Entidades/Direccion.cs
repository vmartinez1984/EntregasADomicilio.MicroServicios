using Google.Cloud.Firestore;

namespace EntregasADomicilio.Web.Pedidos.Core.Entidades
{
    [FirestoreData]
    public class Direccion
    {       
        [FirestoreProperty]
        public string CalleYNumero { get; set; }

        [FirestoreProperty]
        public string Referencias { get; set; }

        [FirestoreProperty]
        public string Alcaldia { get; set; }

        [FirestoreProperty]
        public string Estado { get; set; }

        [FirestoreProperty]
        public string CodigoPostal { get; set; }

        [FirestoreProperty]
        public string CoordenadasGps { get; set; }        
    }
}
