using ECommerce.Dto.CatalogDtos.ProductDtos;
using ECommerce.Dto.CatalogDtos.ProductImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponents.ShopDetailViewComponents
{
    public class _ProductDetailPhotosDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailPhotosDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/ProductImage/ProductImagesByProductId?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(jsonData); // JSON'u konsola yazdır

                // API'den gelen verileri modele dönüştür
                var values = JsonConvert.DeserializeObject<GetByIdProductImageDto>(jsonData);

                // Modeli view'a gönder
                return View(values);
            }
            return View();
        }
    }
}
