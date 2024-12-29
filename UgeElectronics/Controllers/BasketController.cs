using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UgeElectronics.Core.Abstarct;
using UgeElectronics.Core.Entity.Basket;
using UgeElectronics.Core.Repository;
using UgeElectronics.Dtos.BasketDto;

namespace UgeElectronics.Controllers
{
    public class BasketController : ApiBaseController
    {
        private readonly IBasketServies basketServies;

        public BasketController(IBasketServies basketServies)
        {
            this.basketServies = basketServies;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasket>> GetOrCreatBasket(string id)
        {
            var basket = await basketServies.GetOrCreatBasketAsync(id);
            return basket;

        }
        [HttpPost("AddItemInBasket")]
        public async Task<ActionResult<CustomerBasket>> AddBasketItem(int customerBasketId, int productId, int quntity)
        {
            var basket = await basketServies.AddItemInBasketAsync(customerBasketId,productId,quntity);
            return basket;

        }

        [HttpDelete("DeleteItemInBasket{itemId}")]
        public async Task<ActionResult<string>> DeleteBasketItem(int itemId)
        {
            var basket = await basketServies.RemoveItemInBasketAsync(itemId);
            return basket;

        }



    }
}
