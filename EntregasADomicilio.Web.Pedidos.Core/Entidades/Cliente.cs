using Google.Cloud.Firestore;

namespace EntregasADomicilio.Web.Pedidos.Core.Entidades
{
    [FirestoreData]
    public class Cliente
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Nombre { get; set; }

        [FirestoreProperty]
        public string Correo { get; set; }

        [FirestoreProperty]
        public string Telefono { get; set; }

        [FirestoreProperty]
        public string Apellidos { get; set; }

        //[FirestoreProperty]
        //public DateTime FechaDeNacimiento { get; set; }
        //private DateTime fechaDeNacimiento;

        //[FirestoreProperty]
        //public DateTime FechaDeNacimiento
        //{
        //    get { return fechaDeNacimiento.ToUniversalTime(); }
        //    set { fechaDeNacimiento = value; }
        //}

        [FirestoreProperty]
        public Direccion Direccion { get; set; }        
    }
}
