using EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Data;

namespace EntregasADomicilio.Admin.WebData.BusinessLayer.Bl
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IRestauranteBl restauranteBl)
        {
            Restaurante = restauranteBl;
        }

        public IRestauranteBl Restaurante { get; set; }
    }
}
