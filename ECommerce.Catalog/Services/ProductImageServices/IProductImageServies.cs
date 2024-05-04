using ECommerce.Catalog.Dtos.ProductDetailDtos;
using ECommerce.Catalog.Dtos.ProductImageDtos;

namespace ECommerce.Catalog.Services.ProductImageServices
{
    public interface IProductImageServies
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImage(CreateProductImageDto ProductDto);
        Task UpdateProductImage(UpdateProductImageDto ProductDto);
        Task DeleteProductImageAsync(string id);

        Task<GetByIdProductImageDto> GetAllByIdProductImageAsync(string id);
    }
}
