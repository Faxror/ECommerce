namespace ECommerce.Basket.LoginServices
{
    public class LoginServices : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginServices(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
