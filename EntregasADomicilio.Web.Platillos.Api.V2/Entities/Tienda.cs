using Google.Cloud.Firestore;

namespace EntregasADomicilio.Web.Platillos.Api.V2.Entities
{
    [FirestoreData]
    public class Tienda
    {
        [FirestoreProperty]
        public  bool EstaActivo { get;  set; }

        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Nombre { get; set; }

        [FirestoreProperty]
        public string Direccion { get; set; }

        [FirestoreProperty]
        public string CoordenadasGps { get; set; }

        [FirestoreProperty]
        public string Telefono { get; set; }

        [FirestoreProperty]
        public string Correo { get; set; }

        [FirestoreProperty]
        public List<Horario> Horarios { get; set; }

        [FirestoreProperty]
        public List<Tarjeta> Tarjetas { get; set; }

        [FirestoreProperty]
        public AcercaDeNosotros AcercaDeNosotros { get; set; }
    }

    [FirestoreData]
    public class Tarjeta
    {
        [FirestoreProperty]
        public string Icono { get; set; }

        [FirestoreProperty]
        public string Titulo { get; set; }

        [FirestoreProperty]
        public string Contenido { get; set; }
    }

    [FirestoreData]
    public class Horario
    {
        [FirestoreProperty]
        public string Dias { get; set; }

        [FirestoreProperty("Horarios")]
        public string Horas { get; set; }
    }

    [FirestoreData]
    public class AcercaDeNosotros
    {
        [FirestoreProperty]
        public string Titulo { get; set; }

        [FirestoreProperty]
        public string Contenido { get; set; }
    }

}
