using ECommerce.Catalog.Dtos.ProductDetailDtos;
using ECommerce.Catalog.Dtos.ProductDtos;

namespace ECommerce.Catalog.Services.PrductDetailServices
{
    public interface IProductDetailServices
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetail(CreateProductDetailDto ProductDto);
        Task UpdateProductDetail(UpdateProductDetailDto ProductDto);
        Task DeleteProductDetailAsync(string id);

        Task<GetByIdProductDetailDto> GetAllByIdProductDetailAsync(string id);
    }
}
