using Google.Cloud.Firestore;
using System;

namespace EntregasADomicilio.Admin.Platillos.Core.Entidades
{
    [FirestoreData]
    public class Archivo
    {
        [FirestoreProperty]
        public string RutaDelArchivo { get; set; }

        [FirestoreProperty]
        public string NombreDelAlmacen { get; set; }

        [FirestoreProperty]
        public string NombreDelArchivo { get; set; }

        [FirestoreProperty]
        public string ContentType { get; set; }

        [FirestoreProperty]
        public bool EstaActivo { get; set; }

        private DateTime fechaDeRegistro;

        [FirestoreProperty]
        public DateTime FechaDeRegistro
        {
            get { return fechaDeRegistro.ToUniversalTime(); }
            set { fechaDeRegistro = value; }
        }


        [FirestoreProperty]
        public string AliasDelArchivo { get; set; }
    }
}
