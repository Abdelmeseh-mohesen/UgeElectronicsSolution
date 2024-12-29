using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sales_System.Repository.AppDbContext;
using System.Linq;
using UgeElectronics.Core.Entity;
using UgeElectronics.Core.Entity.Order_Aggregation;
using UgeElectronics.Core.Services;
namespace UgeElectronics.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Order> CreateOrderAsync(int basketId, string buyerEmail, int deliveryMethodId, Address shippingAdress)
        {

              var basket = await _context.CustomerBaskets.Include(i=>i.Items)
               .FirstOrDefaultAsync(bi=>bi.Id == basketId);   
        
            var orderItem = new List<OrderItem>();
            if (basket?.Items?.Count > 0)
            {
                foreach (var item in basket.Items)
                {
                    var product = await _context.Products.FirstOrDefaultAsync(i=>i.Id==item.productId);
                    var productItemOrder = new ProductItemsOrder {    
                    PictcurUrl= product!.ProductImage,
                    ProductId= product.Id,
                    ProductName = product.Name,
                    };
                    var Addorderitem = new OrderItem
                    {
                       
                        product = productItemOrder,
                        price = product.Price,
                        Quantity = item.Quantity,
                    };

                   orderItem.Add(Addorderitem);
                }
                var subTotal = orderItem.Sum(item => item.price * item.Quantity);

                var deliveryMethod = await _context.Deliverymethods.FirstOrDefaultAsync(d=>d.Id==deliveryMethodId);

                var order = new Order
                {
                    BuyerEmail = buyerEmail,
                    Deliverymethod = deliveryMethod!,
                    Items = orderItem,
                    SubTotal = subTotal,
                    ShippingAddress = shippingAdress,
                    TotalPrice = deliveryMethod != null ? subTotal + deliveryMethod.Cost : subTotal,
                };
                _context.CustomerBaskets.Remove(basket);
                await  _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();

                return order;
            }
            return null;
        }

        public Task<List<Order>> GetOrderAsync()
        {
            var orders = _context.Orders
                .Include(o=>o.ShippingAddress)
                .Include(d=>d.Deliverymethod)
                .Include(oi=>oi.Items).ToListAsync();
            return orders;
        }

        public Task<Order> GetOrderByIdAsync(int id)
        {
            var order = _context.Orders
               .Include(o => o.ShippingAddress)
               .Include(d => d.Deliverymethod)
               .Include(oi => oi.Items).FirstOrDefaultAsync(i=>i.Id==id);
            return order;
        }
    }
}
