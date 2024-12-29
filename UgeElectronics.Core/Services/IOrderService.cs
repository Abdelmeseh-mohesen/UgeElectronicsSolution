
using UgeElectronics.Core.Entity;
using UgeElectronics.Core.Entity.Order_Aggregation;

namespace UgeElectronics.Core.Services
{
    public interface IOrderService
    {
        public Task<Order> CreateOrderAsync(int basketId, string buyerEmail, int deliveryMethodId, Address shippingAdress);
        public Task<List<Order>> GetOrderAsync();
        public Task<Order> GetOrderByIdAsync(int id);
    }
}
