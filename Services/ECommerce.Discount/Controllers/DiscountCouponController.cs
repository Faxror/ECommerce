using ECommerce.Discount.Dtos;
using ECommerce.Discount.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCouponController : ControllerBase
    {
        private readonly IDiscountService _couponService;

        public DiscountCouponController(IDiscountService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet]
        public async Task<IActionResult> ListDiscountCoupon()
        {
            var valuse = await _couponService.GetCouponAllList();
            return Ok(valuse);
        }

        [HttpGet("{ıd}")]
        public async Task<IActionResult> GetByIdDiscountCouponList(int id)
        {
            var valuse = await _couponService.GetAllByIdCouponList(id);
            return Ok(valuse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateCouponDto createCouponDto)
        {
            await _couponService.CreateCoupon(createCouponDto);
            return Ok("Başarılı şekilde eklendi.");    
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
          await _couponService.DeleteCoupon(id);
            return Ok("Başarılı şekilde silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateCouponDto updateCouponDto)
        {
            await _couponService.UpdateCoupon(updateCouponDto);
            return Ok("Başarılı şekilde güncellendi");
        }
    }
}
