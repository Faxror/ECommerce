using ECommerce.Catalog.Dtos.FeatureSliderDtos;
using ECommerce.Catalog.Services.FeatureSliderServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderServices _FeatureSliderServices;

        public FeatureSlidersController(IFeatureSliderServices FeatureSliderServices)
        {
            _FeatureSliderServices = FeatureSliderServices;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureSliderGetList()
        {
            var valuese = await _FeatureSliderServices.GetAllFeatureSliderAsync();
            return Ok(valuese);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FeatureSliderByIdList(string id)
        {
            var valuse = await _FeatureSliderServices.GetAllByIdCategoriesAsync(id);
            return Ok(valuse);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategories(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _FeatureSliderServices.CreateFeatureSlider(createFeatureSliderDto);
            return Ok("Başarılı şekilde eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategories(string id)
        {
            await _FeatureSliderServices.DeleteFeatureSliderAsync(id);
            return Ok("Başarılı şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategories(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _FeatureSliderServices.UpdateFeatureSlider(updateFeatureSliderDto);
            return Ok("Başarılı şekilde güncellendi");
        }
    }
}
