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

        public Task<Pedido> ObtenerPorIdAsync(string pedidoId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Pedido>> ObtenerTodosPorClienteIdAsync(string clienteID)
        {
            throw new NotImplementedException();
        }
    }
}
