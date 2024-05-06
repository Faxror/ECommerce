using ECommerce.Basket.Dtos;
using ECommerce.Basket.LoginServices;
using ECommerce.Basket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService  _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var user = User.Claims;
            var value = await _basketService.getBasket(_loginService.GetUserId);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasketDetail(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Sebetdeki değişikler kaydedildi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Sebet başarılı ile silindi");
        }
    }
}
