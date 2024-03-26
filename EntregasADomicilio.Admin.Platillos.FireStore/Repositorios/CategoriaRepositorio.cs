using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntregasADomicilio.Admin.Platillos.Core.Entidades;
using EntregasADomicilio.Admin.Platillos.Core.Interfaces;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace EntregasADomicilio.Admin.Platillos.FireStore.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        string ruta = "entregasadomicilio-7e116.json";
        string projectId;
        FirestoreDb _firestoreDb;
        string coleccion = "categorias";

        public CategoriaRepositorio()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", ruta);
            projectId = "entregasadomicilio-7e116";
            _firestoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<List<Categoria>> ObtenerTodosAsync()
        {
            //Filter filter = Filter.EqualTo(nameof(Categoria.EstaActivo), true);
            Query query = _firestoreDb.Collection(coleccion);//.Where(filter);
            QuerySnapshot documentSnapshots = await query.GetSnapshotAsync();
            List<Categoria> lista = new List<Categoria>();
            foreach (var item in documentSnapshots)
            {
                if (item.Exists)
                {
                    Dictionary<string, object> data = item.ToDictionary();
                    string json = JsonConvert.SerializeObject(data);
                    Categoria categoria = JsonConvert.DeserializeObject<Categoria>(json);                    

                    lista.Add(categoria);
                }
            }

            return lista;
        }

        public async Task<string> AgregarAsync(Categoria categoria)
        {
            CollectionReference collectionReference;

            collectionReference = _firestoreDb.Collection(coleccion);
            var data = await collectionReference.AddAsync(categoria);

            return categoria.Id;
        }

        public async Task Actualizar(Categoria categoria)
        {
            string id;

            id = await ObtenerPath(categoria.Id);
            DocumentReference documentReference = _firestoreDb.Collection(coleccion).Document(id);
            await documentReference.SetAsync(categoria, SetOptions.Overwrite);
        }

        public async Task<string> ObtenerPath(string id)
        {
            Filter filter = Filter.EqualTo(nameof(Categoria.Id), id);
            Query query = _firestoreDb.Collection(coleccion).Where(filter);
            QuerySnapshot documentSnapshots = await query.GetSnapshotAsync();
            if (documentSnapshots[0].Exists)
            {
                Dictionary<string, object> data = documentSnapshots[0].ToDictionary();
                string json = JsonConvert.SerializeObject(data);
                Categoria persona = JsonConvert.DeserializeObject<Categoria>(json);
            }
            return documentSnapshots[0].Id;
        }

        public async Task<Categoria> ObtenerPorIdAsync(string id)
        {
            Categoria categoria;

            Filter filter = Filter.EqualTo(nameof(Categoria.Id), id);
            Query query = _firestoreDb.Collection(coleccion).Where(filter);
            QuerySnapshot documentSnapshots = await query.GetSnapshotAsync();
            var item = documentSnapshots[0];
            if (item.Exists)
            {
                Dictionary<string, object> data = item.ToDictionary();
                string json = JsonConvert.SerializeObject(data);
                categoria = JsonConvert.DeserializeObject<Categoria>(json);

            }
            else
                categoria = null;

            return categoria;
        }

        public async Task<bool> ExisteAsync(string categoria)
        {
            Filter filter = Filter.EqualTo(nameof(Categoria.Nombre), categoria);
            Query query = _firestoreDb.Collection(coleccion).Where(filter);            
            QuerySnapshot documentSnapshots = await query.GetSnapshotAsync();
            if(documentSnapshots.Count == 0)
            {
                query = _firestoreDb.Collection(coleccion).Where(Filter.EqualTo(nameof(Categoria.Id), categoria));
                documentSnapshots = await query.GetSnapshotAsync();
            }
            return documentSnapshots[0].Exists;
        }
    }
}
