using Dapper;
using ECommerce.Discount.Context;
using ECommerce.Discount.Dtos;

namespace ECommerce.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCoupon(CreateCouponDto createCouponDto)
        {
            string quary = "insert into Coupons (Code, Rate, IsActive, ValidDate) values (@code, @rate, @isActive, @validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(quary, parameters);
            };
        }

        public async Task DeleteCoupon(int id)
        {
            string quary = "Delete From Coupons where CouponId=@CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("CouponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(quary, parameters);
            };
        }

        public async Task<GetByIdCouponDto> GetAllByIdCouponList(int id)
        {
            string quary = "Select * From Coupons Where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(quary, parameters);
                return values;
            };
        }

        public async Task<List<ResultCouponDto>> GetCouponAllList()
        {
            string quary = "Select * From Coupons";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(quary);
                return values.ToList();
            };
        }

        public async Task UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            string quary = "Update Coupons Set Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate where  CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(quary, parameters);
            };
        }
    }
}
