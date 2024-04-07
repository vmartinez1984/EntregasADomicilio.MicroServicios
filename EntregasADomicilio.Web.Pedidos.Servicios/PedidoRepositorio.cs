using EntregasADomicilio.Web.Pedidos.Core.Entidades;
using EntregasADomicilio.Web.Pedidos.Core.Interfaces;
using Google.Cloud.Firestore;

namespace EntregasADomicilio.Web.Pedidos.Repositorios.Firestore
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        string ruta = "entregasadomicilio-7e116.json";
        string projectId;
        FirestoreDb _firestoreDb;
        string coleccion = "pedidos";

        public PedidoRepositorio()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", ruta);
            projectId = "entregasadomicilio-7e116";
            _firestoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<string> AgregarAsync(Pedido pedido)
        {
            CollectionReference collectionReference;

            collectionReference = _firestoreDb.Collection(coleccion);
            var data = await collectionReference.AddAsync(pedido);

            return pedido.Id;
        }

        public async Task<Pedido> ObtenerPorIdAsync(string pedidoId)
        {
            Query query;
            QuerySnapshot snapshots;
            Pedido entity;

            query = _firestoreDb.Collection(coleccion)
                .Where(Filter.EqualTo(nameof(Pedido.Id), pedidoId));
            snapshots = await query.GetSnapshotAsync();
            if (snapshots.Count > 0)
                entity = snapshots[0].ConvertTo<Pedido>();
            else
                entity = null;

            return entity;
        }

        public async Task<List<Pedido>> ObtenerTodosPorClienteIdAsync(string clienteID)
        {
            Query query;
            QuerySnapshot snapshots;
            List<Pedido> list;

            query = _firestoreDb.Collection(coleccion)
                .Where(Filter.EqualTo(nameof(Pedido.Cliente.Id), clienteID));
            snapshots = await query.GetSnapshotAsync();
            list = new List<Pedido>();
            foreach (var item in snapshots)
            {
                list.Add(item.ConvertTo<Pedido>()); 
            }

            return list;
        }
    }
}
