using EntregasADomicilio.Web.Platillos.Api.V2.Entities;

namespace EntregasADomicilio.Web.Platillos.Api.V2.Interfaces
{
    public interface IRepositorio
    {
        public IPlatillo Platillo { get; }

        public ICategoria Categoria { get; }

        public ITienda Tienda { get; }
    }

    public interface ITienda
    {
        Task<Tienda> ObtenerAsync();
    }
}
