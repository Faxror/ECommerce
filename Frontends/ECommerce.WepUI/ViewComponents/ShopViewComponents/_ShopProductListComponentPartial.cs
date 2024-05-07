using ECommerce.Dto.CatalogDtos.CategoryDtos;
using ECommerce.Dto.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponents.ShopViewComponents
{
    public class _ShopProductListComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ShopProductListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/Product/ProductListWithCategoryByCategoryId?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine("API'den dönen veri: " + jsonData); // API'den dönen veriyi konsola yazdır
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            else
            {
                Console.WriteLine("API çağrısı başarısız. Hata kodu: " + responseMessage.StatusCode); // Hata durumunu konsola yazdır
            }

            return View(new List<ResultProductWithCategoryDto>()); // Boş bir liste döndür
        }

    }
}
