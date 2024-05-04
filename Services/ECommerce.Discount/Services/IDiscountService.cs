using ECommerce.Discount.Dtos;

namespace ECommerce.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetCouponAllList();

        Task CreateCoupon(CreateCouponDto createCouponDto);
        Task UpdateCoupon(UpdateCouponDto updateCouponDto);
        Task DeleteCoupon(int id);

        Task<GetByIdCouponDto> GetAllByIdCouponList(int id);
    }
}
