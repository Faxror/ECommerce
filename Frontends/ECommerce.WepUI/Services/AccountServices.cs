using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ECommerce.WebUI.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AccountServices(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
