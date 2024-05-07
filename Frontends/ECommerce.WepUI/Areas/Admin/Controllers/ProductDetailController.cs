using ECommerce.Dto.CatalogDtos.ProductDetailDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("UpdateProductDetail/{id}")]
        [HttpGet]
        public async Task<ActionResult> UpdateProductDetail(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/ProductDetail/GetProductDetailByProductİd?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(jsonData); // Gelen JSON'u konsola yazdırır

                var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                if (values != null)
                {
                    Console.WriteLine("Model not null: " + values.ProductDetailID); // Modelin null olmadığını ve gerekli özelliğin alınıp alınmadığını kontrol eder

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


        [Route("UpdateProductDetail/{id}")]
        [HttpPost]
        public async Task<ActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7047/api/ProductDetail/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            return View();
        }

    }
}
