using ECommerce.Dto.CatalogDtos.SpecialOfferDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [AllowAnonymous]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBagCategories();

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/SpecialOffer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            return View();
        }


        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7047/api/SpecialOffer", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            else
            {
                string errorMessage = await responseMessage.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorMessage);
                return View(dto); // Hata ile birlikte view döndürülüyor
            }
        }



        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7047/api/SpecialOffer?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }

            return View();

        }
  


        [Route("UpdateSpecialOffer/{id}")]
        [HttpGet]
        public async Task<ActionResult> UpdateSpecialOffer(string id)
        {


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/SpecialOffer/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(jsonData); // JSON'u konsola yazdır

                // API'den gelen verileri modele dönüştür
                var values = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);

                // Modeli view'a gönder
                return View(values);
            }
            return View();
        }



        [Route("UpdateSpecialOffer/{id}")]
        [HttpPost]
        public async Task<ActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto specialOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(specialOfferDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7047/api/SpecialOffer/", stringContent);
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
                return View(specialOfferDto);
            }
        }

       

        public void ViewBagCategories()
        {
            ViewBag.title = "SpecialOffers İşlemleri";
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "SpecialOffer";
            ViewBag.v3 = "SpecialOffer İşlemleri";
        }
    }
}
