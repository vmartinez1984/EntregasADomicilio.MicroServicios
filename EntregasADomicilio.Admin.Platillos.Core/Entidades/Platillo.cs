using Google.Cloud.Firestore;
using System.Collections.Generic;

namespace EntregasADomicilio.Admin.Platillos.Core.Entidades
{
    [FirestoreData]

    public class Platillo
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Categoria { get; set; }

        [FirestoreProperty]
        public string Nombre { get; set; }

        [FirestoreProperty]
        public string Descripcion { get; set; }

        [FirestoreProperty]
        public double Precio { get; set; }

        [FirestoreProperty]
        public bool EstaActivo { get; set; } = true;

        [FirestoreProperty]       
        public List<Archivo> ListaDeArchivos { get; set; }
    }
}
