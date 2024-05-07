using ECommerce.Dto.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponents.ShopDetailViewComponents
{
    public class _ProductDetailPriceDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailPriceDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id) 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/Product/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(jsonData); // JSON'u konsola yazdır

                // API'den gelen verileri modele dönüştür
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);

                // Modeli view'a gönder
                return View(values);
            }
            return View();
        }
    }
}
