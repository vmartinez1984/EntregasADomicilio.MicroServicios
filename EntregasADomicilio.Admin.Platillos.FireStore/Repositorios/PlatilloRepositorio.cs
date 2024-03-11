using EntregasADomicilio.Admin.Platillos.Core.Entidades;
using EntregasADomicilio.Admin.Platillos.Core.Interfaces;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.Platillos.FireStore.Repositorios
{
    public class PlatilloRepositorio : IPlatilloRepositorio
    {
        string ruta = ".\\entregasadomicilio-7e116.json";
        string projectId;
        FirestoreDb _firestoreDb;
        string coleccion = "platillos";

        public PlatilloRepositorio()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", ruta);
            projectId = "entregasadomicilio-7e116";
            _firestoreDb = FirestoreDb.Create(projectId);
        }

        public async Task ActualizarAsync(Platillo item)
        {
            string path;

            path = await ObtenerPath(item.Id);
            DocumentReference documentReference = _firestoreDb.Collection(coleccion).Document(path);

            await documentReference.SetAsync(item, SetOptions.Overwrite);
        }

        public async Task<string> ObtenerPath(string id)
        {
            Filter filter = Filter.EqualTo(nameof(Platillo.Id), id);
            Query query = _firestoreDb.Collection(coleccion).Where(filter);
            QuerySnapshot documentSnapshots = await query.GetSnapshotAsync();

            return documentSnapshots[0].Id;
        }

        public async Task<string> AgregarAsync(Platillo entity)
        {
            CollectionReference collectionReference = _firestoreDb.Collection(coleccion);
            await collectionReference.AddAsync(entity);

            return entity.Id;
        }

        public async Task<Platillo> ObtenerPorIdAsync(string platilloId)
        {
            Query query;
            QuerySnapshot documentSnapshots;
            Platillo platillo = null;

            query = _firestoreDb.Collection(coleccion).Where(Filter.EqualTo(nameof(Platillo.Id), platilloId));
            documentSnapshots = await query.GetSnapshotAsync();
            if (documentSnapshots.Count > 0)
            {
                //Dictionary<string, object> data = item.ToDictionary();
                //string json = JsonConvert.SerializeObject(data);
                platillo = documentSnapshots[0].ConvertTo<Platillo>();
            }

            return platillo;
        }

        public async Task<List<Platillo>> ObtenerTodosAsync(bool? estaActivo = null)
        {
            List<Platillo> platillos;
            Query query;
            QuerySnapshot documentSnapshots;


            platillos = new List<Platillo>();
            if (estaActivo == null)
                query = _firestoreDb.Collection(coleccion);
            else
                query = _firestoreDb.Collection(coleccion).Where(Filter.EqualTo(nameof(Platillo.EstaActivo), estaActivo));
            documentSnapshots = await query.GetSnapshotAsync();
            platillos = documentSnapshots.Select(x => x.ConvertTo<Platillo>()).ToList();

            return platillos;
        }
    }
}
