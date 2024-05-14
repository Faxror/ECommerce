using ECommerce.Dto.IdentityServerDto;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using ECommerce.WebUI.Services;

namespace ECommerce.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IIdentityServerServices _identityServerServices;

        public AccountController(IHttpClientFactory httpClientFactory, IIdentityServerServices identityServerServices)
        {
            _httpClientFactory = httpClientFactory;
            _identityServerServices = identityServerServices;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateIdentityDto createIdentityDto)
        {
            if (createIdentityDto.Password == createIdentityDto.Password)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createIdentityDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:5001/api/Account/Register", stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    string errorMessage = await responseMessage.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, errorMessage);
                    return View(createIdentityDto); // Hata ile birlikte view döndürülüyor
                }
            }
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(CreateLoginDto createLoginDto)
        {

            var client = _httpClientFactory.CreateClient();
            var contant = new StringContent(System.Text.Json.JsonSerializer.Serialize(createLoginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5001/api/Account/Login", contant);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = System.Text.Json.JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }); if (tokenModel != null)
                {
                    JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                    var token = jwtSecurityTokenHandler.ReadJwtToken(tokenModel.Token);
                    var claim = token.Claims.ToList();

                    if (tokenModel.Token != null)
                    {
                        claim.Add(new Claim("eticarettoken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claim, JwtBearerDefaults.AuthenticationScheme);
                        var authprop = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireTime,
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authprop);
                        return RedirectToAction("Index", "Default");
                    }
                }
            }
            return View();
        }


        //[HttpGet]
        //public IActionResult SignUp()
        //{
        //    return View();
        //}

        //[HttpPost]
        public async Task<IActionResult> SignUp(SingInDto singInDto)
        {
            singInDto.Username = "Merce";
            singInDto.Password = "111111aA*";
            await _identityServerServices.SignIn(singInDto);
            return RedirectToAction("Index", "test");
        }
    }
}
