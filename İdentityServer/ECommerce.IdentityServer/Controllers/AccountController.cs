using ECommerce.IdentityServer.Dtos;
using ECommerce.IdentityServer.Models;
using ECommerce.IdentityServer.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace ECommerce.IdentityServer.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _UserManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var valuse = new ApplicationUser()
            {
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
            };
            var result = await _UserManager.CreateAsync(valuse, userRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok("Başarılı şekilde oluştu");
            }
            else
            {
                return Ok("Hata!");
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> UserLogin(UserLoginDto userRegisterDto)
        {
            var valuse = await _signInManager.PasswordSignInAsync(userRegisterDto.Username, userRegisterDto.Password, false, true);
            var user = await _UserManager.FindByNameAsync(userRegisterDto.Username);
            if (valuse.Succeeded)
            {
              GetChectAppUserViewModel model = new GetChectAppUserViewModel();
              model.Username = userRegisterDto.Username;
                model.Id = user.Id;
                var token = JwtTokenGenerator.GenerateToken(model);
                return Ok(token);
            }
            else { return Ok("Kullanıcı adı ve ya şifre hatalı"); }
        }
    }
}
