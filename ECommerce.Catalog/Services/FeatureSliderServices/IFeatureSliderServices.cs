using ECommerce.Catalog.Dtos.CategoryDtos;
using ECommerce.Catalog.Dtos.FeatureSliderDtos;

namespace ECommerce.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderServices
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureSlider(UpdateFeatureSliderDto FeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);

        Task<GetByIdFeatureSliderDto> GetAllByIdCategoriesAsync(string id);

        Task FeatureSliderChageStatusToTrue(string id);
        Task FeatureSliderChageStatusToFalse(string id);
    }
}
