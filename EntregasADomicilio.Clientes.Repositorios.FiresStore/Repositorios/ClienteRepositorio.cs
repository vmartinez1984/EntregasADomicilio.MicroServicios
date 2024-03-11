using EntregasADomicilio.Usuarios.Core.Entities;
using EntregasADomicilio.Usuarios.Core.Interfaces;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasADomicilio.Usuarios.Repositorios.FiresStore.Clientes
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        string ruta = ".\\entregasadomicilio-7e116.json";
        string projectId;
        FirestoreDb _firestoreDb;
        string coleccion = "clientes";

        public ClienteRepositorio()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", ruta);
            projectId = "entregasadomicilio-7e116";
            _firestoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<string> AgregarClienteAsync(Cliente cliente)
        {
            CollectionReference collectionReference;

            collectionReference = _firestoreDb.Collection(coleccion);
            var data = await collectionReference.AddAsync(cliente);

            return cliente.Id;
        }

        public async Task<Cliente> ObtenerAsync(string id)
        {
            Cliente cliente;
            QuerySnapshot querySnapshot;
            Query query;

            query = _firestoreDb.Collection(coleccion)
                .Where(Filter.EqualTo(nameof(Cliente.UsuarioId), id.ToString()));
            querySnapshot = await query.GetSnapshotAsync();
            cliente = null;
            if (querySnapshot.Count() > 0 && querySnapshot[0].Exists)
            {                
                cliente = querySnapshot[0].ConvertTo<Cliente>();
            }

            return cliente;
        }
    }
}
