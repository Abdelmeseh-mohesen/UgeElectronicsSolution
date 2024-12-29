using Microsoft.EntityFrameworkCore;
using Sales_System.Repository.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgeElectronics.Core.Abstarct;
using UgeElectronics.Core.Entity.Basket;

namespace UgeElectronics.Repositry
{
    public class BasketServies : IBasketServies
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BasketServies(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }


        public async Task<CustomerBasket> GetOrCreatBasketAsync(string customerId)
        {
          var customerBasket= await applicationDbContext.CustomerBaskets.Include(i => i.Items).ThenInclude(i => i.Product).FirstOrDefaultAsync(c => c.CustomerId.Equals(customerId));
            if (customerBasket == null) {
                var basket = new CustomerBasket { CustomerId = customerId };
              
             await applicationDbContext.CustomerBaskets.AddAsync(basket);
               await applicationDbContext.SaveChangesAsync();   
            
            }
            return (customerBasket);
        }

        public Task<CustomerBasket> UbdateBasketAsync(CustomerBasket Basket)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteBasketAsync(string BasketId)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerBasket> AddItemInBasketAsync(int customerBasket, int productId, int quntity)
        {
            var basket = await applicationDbContext.CustomerBaskets.FirstOrDefaultAsync(b => b.Id == customerBasket);
            if (basket == null) return null!;
            var basketitem = new BasketItems
            {
               BasketId = basket.Id,
               productId = productId,
               Quantity = quntity
            };
            basket.Items.Add(basketitem);
            await applicationDbContext.SaveChangesAsync();
            return (basket);
        }

        public async Task<string> RemoveItemInBasketAsync(int ItemId)
        {
            var item = await applicationDbContext.BasketItems.FirstOrDefaultAsync(i => i.Id== ItemId);
            if (item!=null)
            {
                applicationDbContext.Remove(item);
                await applicationDbContext.SaveChangesAsync();
                return "Delete Succssefully";
            }
            return "Faild Delete Item";

        }
    }
}
