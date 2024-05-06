using ECommerce.Catalog.Dtos.ProductDtos;
using ECommerce.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var valuse = await _productServices.GetAllProductAsync();
            return Ok(valuse);  
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductList(string id)
        {
            var valuse = await _productServices.GetAllByIdProductAsync(id);
            return Ok(valuse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productServices.CreateProduct(createProductDto);
            return Ok("Başarılı şekilde eklendi");
        }

        [HttpDelete] 
        public async Task<IActionResult> DeleteProduct(string id) 
        { 
            await _productServices.DeleteProductAsync(id);
            return Ok("Başarılı şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productServices.UpdateProduct(updateProductDto);
            return Ok("Başarılı şekilde güncellendi");
        }
    }
}
