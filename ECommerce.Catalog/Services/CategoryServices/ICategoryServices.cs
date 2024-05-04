using ECommerce.Catalog.Dtos.CategoryDtos;

namespace ECommerce.Catalog.Services.CategoryServices
{
    public interface ICategoryServices
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategory(CreateCategoryDto createCategoryDto);
        Task UpdateCategory(UpdateCategoryDto categoryDto);
        Task DeleteCategoryAsync(string id);

        Task<GetByIdCategoryDto> GetAllByIdCategoriesAsync(string id);
    }
}
