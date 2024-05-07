using ECommerce.Dto.CatalogDtos.FeatureSliderDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureSliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [AllowAnonymous]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBagCategories();

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/FeatureSliders");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateFeatureSlider")]
        public IActionResult CreateFeatureSlider()
        {
            return View();
        }


        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto dto)
        {
            dto.Status = false;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7047/api/FeatureSliders", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            else
            {
                string errorMessage = await responseMessage.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorMessage);
                return View(dto); // Hata ile birlikte view döndürülüyor
            }
        }



        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7047/api/FeatureSliders?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }

            return View();

        }
        [Route("UpdateFeatureSlider/{id}")]
        [HttpGet]
        public async Task<ActionResult> UpdateFeatureSlider(string id)
        {
            ViewBagCategories();



            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/FeatureSliders/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(jsonData); // JSON'u konsola yazdır

                // API'den gelen verileri modele dönüştür
                var values = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);

                // Modeli view'a gönder
                return View(values);
            }
            return View();
        }

        [Route("UpdateFeatureSlider/{id}")]
        [HttpPost]
        public async Task<ActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeatureSliderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7047/api/FeatureSliders/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            else
            {
                string errorMessage = await responseMessage.Content.ReadAsStringAsync();
                // Hatayı logla
                Console.WriteLine(errorMessage);
                ModelState.AddModelError(string.Empty, errorMessage);
                Console.WriteLine($"Hata Kodu: {responseMessage.StatusCode}, Hata Mesajı: {errorMessage}");
                // Hata ile birlikte view döndürülüyor
                return View(updateFeatureSliderDto);
            }
        }

        public void ViewBagCategories()
        {
            ViewBag.title = "FeatureSliders İşlemleri";
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "FeatureSlider";
            ViewBag.v3 = "FeatureSlider İşlemleri";
        }
    }
}
