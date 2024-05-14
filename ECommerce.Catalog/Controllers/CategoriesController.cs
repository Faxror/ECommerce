using ECommerce.Catalog.Dtos.CategoryDtos;
using ECommerce.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryGetList()
        {
            var valuese = await _categoryServices.GetAllCategoryAsync();
            return Ok(valuese);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CategoryByIdList (string id)
        {
            var valuse = await _categoryServices.GetAllByIdCategoriesAsync(id);
            return Ok(valuse);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategories(CreateCategoryDto createCategoryDto)
        {
          await  _categoryServices.CreateCategory(createCategoryDto);
            return Ok("Başarılı şekilde eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategories(string id)
        {
            await _categoryServices.DeleteCategoryAsync(id);
            return Ok("Başarılı şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategories(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryServices.UpdateCategory(updateCategoryDto);
            return Ok("Başarılı şekilde güncellendi");
        }

    }
}
