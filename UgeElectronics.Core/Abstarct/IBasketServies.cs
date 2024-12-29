using UgeElectronics.Core.Entity.Basket;
namespace UgeElectronics.Core.Abstarct

{
    public interface IBasketServies
    {

        Task<CustomerBasket> UbdateBasketAsync(CustomerBasket Basket);
        Task<CustomerBasket> AddItemInBasketAsync(int customerBasket  , int productId , int quntity );
        Task<string> RemoveItemInBasketAsync( int ItemId );
        Task<CustomerBasket> GetOrCreatBasketAsync(string CustomerId);
        Task<bool> DeleteBasketAsync(string BasketId);

    }
}
