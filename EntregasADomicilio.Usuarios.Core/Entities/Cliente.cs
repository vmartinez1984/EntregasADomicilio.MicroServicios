using Google.Cloud.Firestore;

namespace EntregasADomicilio.Usuarios.Core.Entities
{
    [FirestoreData]
    public class Cliente
    {
        [FirestoreProperty]
        public string UsuarioId { get; set; }

        [FirestoreProperty]
        public  string Apellidos { get; set; }

        [FirestoreProperty]
        public  string Correo { get; set; }

        [FirestoreProperty]
        public  string Id { get; set; }

        [FirestoreProperty]
        public  string Nombre { get; set; }

        [FirestoreProperty]
        public  string Telefono { get; set; }

        [FirestoreProperty]
        public List<Direccion> Direcciones { get; set; }
    }

    [FirestoreData]
    public class Direccion
    {
        [FirestoreProperty]
        public string Alcaldia { get; set; }

        [FirestoreProperty]
        public string CalleYNumero { get; set; }

        [FirestoreProperty]
        public string CodigoPostal { get; set; }

        [FirestoreProperty]
        public string Colonia { get; set; }

        [FirestoreProperty]
        public string CoordenadasGps { get; set; }

        [FirestoreProperty]
        public bool EsLaPrincipal { get; set; }

        [FirestoreProperty]
        public string Estado { get; set; }

        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Referencia { get; set; }
    }
}
