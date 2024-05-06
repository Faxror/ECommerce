using ECommerce.IdentityServer.Dtos;
using ECommerce.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace ECommerce.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _UserManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _UserManager = userManager;
        }

        [HttpPost]
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
    }
}
