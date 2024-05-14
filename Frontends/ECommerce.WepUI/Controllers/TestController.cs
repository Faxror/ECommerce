using ECommerce.Dto.CatalogDtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace ECommerce.WebUI.Controllers
{
    public class TestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            // Token değişkeni tanımladık.
            string token = "";
            //HttpClient tanımladım
            using (var HttpClient = new HttpClient())
            {
                //HttpMessage Sınıfı kullandık.
                var request = new HttpRequestMessage
                {
                    //HttpMessage kullanarak, token oluşturma işlemlerini yaptık, method post
                    RequestUri = new Uri("https://localhost:5001/connect/token"),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"client_id", "ECommerceVisitor"},
                        {"client_secret", "ecommercesecretadmins"},
                        {"grant_type", "client_credentials"}
                    })



                };
                //Mesaj'ı gönderiyoruz.
                using (var response = await HttpClient.SendAsync(request))
                {
                    //Eğer doğru dönerse nill olmazsa
                    if (response.IsSuccessStatusCode)
                    {
                        //Respondeden gelen token'ı string olarak okuma
                        var context = await response.Content.ReadAsStringAsync();
                        // TokenResponse oluşturma
                        var tokenResponse = JObject.Parse(context);
                         //ToeknResponse'den gelen "access_Token"'i okuma
                        token = tokenResponse["access_token"].ToString();
                    }
                }

            }


            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await client.GetAsync("https://localhost:7047/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
