using ECommerce.Catalog.Dtos.CategoryDtos;
using ECommerce.Catalog.Dtos.ProductDtos;

namespace ECommerce.Catalog.Services.ProductServices
{
    public interface IProductServices
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProduct(CreateProductDto ProductDto);
        Task UpdateProduct(UpdateProductDto ProductDto);
        Task DeleteProductAsync(string id);

        Task<GetByIdProductDto> GetAllByIdProductAsync(string id);

        Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIdAsync(string CategoryId);
    }
}
