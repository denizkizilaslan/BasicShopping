using BasicShopping.Entities.Concrete;

namespace BasicShopping.DataAccess.Redis.Abstract
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string customerId);

        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

        Task<bool> DeleteBasketAsync(string customerId);
    }
}
