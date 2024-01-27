
using System;
using System.Text.Json;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
           var data = await _database.StringGetAsync(basketId);

           return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
           var created = await _database.StringSetAsync(basket.Id,JsonSerializer.Serialize(basket),TimeSpan.FromDays(30));
           if(!created) return null!;

           return await GetBasketAsync(basket.Id);

        }
    public async Task<List<CustomerBasket>> GetAllBasketsAsync()
    {
    var baskets = new List<CustomerBasket>();

    // Using the SCAN command to iterate over keys
    var cursor = 0L;
    do
    {
        var result = await _database.ExecuteAsync("SCAN", cursor.ToString(), "MATCH", "*", "COUNT", "1000");
        var innerResult = (RedisResult[]?)result;

        // The first element is the new cursor, and the second element is an array of keys
        cursor = (long)innerResult[0];
        var keys = (string[]?)innerResult[1];

        foreach (var key in keys!)
        {
            // Use StringGet to retrieve the value for each key
            var value = await _database.StringGetAsync(key);

            if (!value.IsNullOrEmpty)
            {
                var basket = JsonSerializer.Deserialize<CustomerBasket>(value!);
                baskets.Add(basket!);
            }
        }

    } while (cursor != 0);

    return baskets;
}
}
}