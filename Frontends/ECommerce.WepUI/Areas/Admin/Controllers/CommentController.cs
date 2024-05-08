using ECommerce.Dto.CatalogDtos.CommentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
       
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
 
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7018/api/Comments");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7018/api/Comments?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }

            return View();

        }



        [Route("UpdateComment/{id}")]
        [HttpGet]
        public async Task<ActionResult> UpdateComment(string id)
        {


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7018/api/Comments/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(jsonData); // JSON'u konsola yazdır

                // API'den gelen verileri modele dönüştür
                var values = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);

                // Modeli view'a gönder
                return View(values);
            }
            return View();
        }



        [Route("UpdateComment/{id}")]
        [HttpPost]
        public async Task<ActionResult> UpdateComment(UpdateCommentDto CommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(CommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7018/api/Comments/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            else
            {
                string errorMessage = await responseMessage.Content.ReadAsStringAsync();
                // Hatayı logla
                Console.WriteLine(errorMessage);
                ModelState.AddModelError(string.Empty, errorMessage);
                Console.WriteLine($"Hata Kodu: {responseMessage.StatusCode}, Hata Mesajı: {errorMessage}");
                // Hata ile birlikte view döndürülüyor
                return View(CommentDto);
            }
        }



        public void ViewBagCategories()
        {
            ViewBag.title = "Comments İşlemleri";
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Yorum";
            ViewBag.v3 = "Yorum İşlemleri";
        }

    }
}
