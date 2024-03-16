using Google.Cloud.Firestore;

namespace EntregasADomicilio.Web.Platillos.Api.V2.Entities
{
    [FirestoreData]
    public class Categoria
    {
        [FirestoreProperty]        
        public string Id { get; set; }             
       
        [FirestoreProperty]       
        public string Nombre { get; set; }

        [FirestoreProperty]        
        public bool EstaActivo { get; set; } = true;
    }
}
