using BasicShopping.DataAccess.Redis.Abstract;
using BasicShopping.Entities.Concrete;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace BasicShopping.DataAccess.Redis.Concrete
{
    public class RedisBasketRepository : IBasketRepository
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public RedisBasketRepository(ConnectionMultiplexer redis)
        {
            _redis = redis;
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        public async Task<CustomerBasket> GetBasketAsync(string customerId)
        {
            var data = await _database.StringGetAsync(customerId);

            if (data.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var created = await _database.StringSetAsync(basket.CustomerId, JsonConvert.SerializeObject(basket));

            if (!created)
            {
                return null;
            }

            return await GetBasketAsync(basket.CustomerId);
        }

    }
}
