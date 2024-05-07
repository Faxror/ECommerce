using ECommerce.Catalog.Dtos.ProductDetailDtos;
using ECommerce.Catalog.Services.PrductDetailServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailServices _productDetailServices;

        public ProductDetailController(IProductDetailServices productDetailServices)
        {
            _productDetailServices = productDetailServices;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var valuse = await _productDetailServices.GetAllProductDetailAsync();
            return Ok(valuse);
        }

        [HttpGet("GetProductDetailByProductİd")]
        public async Task<IActionResult> ProductDetailList(string id)
        {
            var valuse = await _productDetailServices.GetAllByProductIdProductDetailAsync(id);
            return Ok(valuse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductDetailList(string id)
        {
            var valuse = await _productDetailServices.GetAllByIdProductDetailAsync(id);
            return Ok(valuse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailServices.CreateProductDetail(createProductDetailDto);
            return Ok("Başarılı şekilde eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailServices.DeleteProductDetailAsync(id);
            return Ok("Başarılı şekilde silindi");
        }

        [HttpPut] 
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailServices.UpdateProductDetail(updateProductDetailDto);
            return Ok("Başarılı şekilde güncellendi");
        }
    }
}
