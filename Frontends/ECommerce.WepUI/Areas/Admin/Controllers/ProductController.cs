using ECommerce.Dto.CatalogDtos.CategoryDtos;
using ECommerce.Dto.CatalogDtos.ProductDtos;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [AllowAnonymous]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBagCategories();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/Categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
           List<SelectListItem> categoryList = (from x in values select new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryID
            }).ToList();

            // ViewBag içine ekleyerek View tarafında kullanılabilir hale getir
            ViewBag.CategoryValuess = categoryList;

            return View();
        }


        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            

            // Geçerli bir model ise, API'ye isteği gönderelim
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7047/api/Product", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                // Başarılı yanıt
                var responseData = await responseMessage.Content.ReadAsStringAsync();
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
                return View(dto);
            }

        }



        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7047/api/Product?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            return View();

        }
        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<ActionResult> UpdateProduct(string id)
        {
            ViewBagCategories();

            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:7047/api/Categories");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);
            List<SelectListItem> categoryList1 = (from x in values1
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID
                                                  }).ToList();

            // ViewBag içine ekleyerek View tarafında kullanılabilir hale getir
            ViewBag.CategoryValuess2 = categoryList1;

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



        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<ActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7047/api/Product/", stringContent);
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
                return View(updateProductDto);
            }
        }

        public void ViewBagCategories()
        {
            ViewBag.title = "Ürün İşlemleri";
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
        }

        public async Task GetCategoriesAsync()
        {
            
        }
    }
}
