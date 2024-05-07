using ECommerce.Dto.CatalogDtos.ProductDetailDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponents.ShopDetailViewComponents
{
    public class _ShopDetailDescriptionComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ShopDetailDescriptionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id) 
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
    }
}
