using EntregasADomicilio.Web.Platillos.Core.Entities;
using EntregasADomicilio.Web.Platillos.Core.Interfaces.Repositories;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Platillos.Repositorios.FireStore.Repositorios
{
    public class CategoriaRepositorio : ICategoria
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
            Query query = _firestoreDb.Collection(coleccion).Where(Filter.EqualTo("EstaActivo", true));
            QuerySnapshot documentSnapshots = await query.GetSnapshotAsync();
            List<Categoria> lista = new List<Categoria>();            
            lista = documentSnapshots.Select(x=> x.ConvertTo<Categoria>()).ToList();

            return lista;
        }
    }
}
