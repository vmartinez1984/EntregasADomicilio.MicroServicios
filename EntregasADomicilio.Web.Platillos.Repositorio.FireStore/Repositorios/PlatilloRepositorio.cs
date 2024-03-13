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
    public class PlatilloRepositorio : IPlatillo
    {
        string ruta = "entregasadomicilio-7e116.json";
        string projectId;
        FirestoreDb _firestoreDb;
        string coleccion = "platillos";

        public PlatilloRepositorio()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", ruta);
            projectId = "entregasadomicilio-7e116";
            _firestoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<Platillo?> ObtenerPorIdAsync(string platilloId)
        {
            Query query;
            QuerySnapshot documentSnapshots;
            Platillo platillo = null;

            query = _firestoreDb.Collection(coleccion).Where(Filter.EqualTo(nameof(Platillo.Id), platilloId));
            documentSnapshots = await query.GetSnapshotAsync();
            if (documentSnapshots.Count > 0)
            {
                platillo = documentSnapshots[0].ConvertTo<Platillo>();
            }

            return platillo;
        }

        public async Task<List<Platillo>> ObtenerTodosAsync()
        {
            Query query;
            List<Platillo> lista;
            QuerySnapshot documentSnapshots; 

            query = _firestoreDb.Collection(coleccion).Where(Filter.EqualTo("EstaActivo", true));
            documentSnapshots = await query.GetSnapshotAsync();            
            lista = documentSnapshots.Select(x => x.ConvertTo<Platillo>()).ToList();

            return lista;
        }

    }
}