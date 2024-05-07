using ECommerce.Dto.CatalogDtos.ProductImageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ProductImageController> _logger;

        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            
        }

     

        [Route("ProductImageDetail/{id}")]
        [HttpGet]
        public async Task<ActionResult> ProductImageDetail(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/ProductImage/ProductImagesByProductId?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(jsonData); // Gelen JSON'u konsola yazdırır

                var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
                if (values != null)
                {
                    Console.WriteLine("Model not null: " + values.ProductImageID); // Modelin null olmadığını ve gerekli özelliğin alınıp alınmadığını kontrol eder

                    return View(values);
                }
                else
                {
                    Console.WriteLine("Model null."); // Modelin null olduğunu kontrol eder
                }
            }
            else
            {
                Console.WriteLine("API response unsuccessful: " + responseMessage.StatusCode); // API'den başarısız bir yanıt alındığını kontrol eder
            }
            return View();
        }


        [Route("ProductImageDetail/{id}")]
        [HttpPost]
        public async Task<ActionResult> ProductImageDetail(UpdateProductImageDto updateProductDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7047/api/ProductImage/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            return View();
        }
    }
}
