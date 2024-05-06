using ECommerce.Basket.Dtos;
using ECommerce.Basket.Settings;
using System.Text.Json;

namespace ECommerce.Basket.Services
{
    public class BasketServices : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketServices(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
           var status = await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> getBasket(string userId)
        {
           var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
