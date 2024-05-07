using ECommerce.Catalog.Dtos.ProductImageDtos;
using ECommerce.Catalog.Services.ProductImageServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageServies _productsImageServies;

        public ProductImageController(IProductImageServies productsImageServies)
        {
            _productsImageServies = productsImageServies;
        }

        [HttpGet]
        public async Task<IActionResult> GetListProductIamge() 
        {
            var valuse = await _productsImageServies.GetAllProductImageAsync();
            return Ok(valuse);
        }


        [HttpGet("ProductImagesByProductId")]
        public async Task<IActionResult> ProductImagesByProductId(string id)
        {
            var valuse = await _productsImageServies.GetAllByProductIdProductImageAsync(id);
            return Ok(valuse);
        }
        [HttpGet("{ıd}")]
        public async Task<IActionResult> GetListByIdProductIamge(string id)
        {
            var valuse = await _productsImageServies.GetAllByIdProductImageAsync(id);
            return Ok(valuse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productsImageServies.CreateProductImage(createProductImageDto);
            return Ok("Başarılı şekilde eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productsImageServies.DeleteProductImageAsync(id);
            return Ok("Başarılı şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productsImageServies.UpdateProductImage(updateProductImageDto);
            return Ok("Başarılı şekilde güncellendi");
        }
    }
}
