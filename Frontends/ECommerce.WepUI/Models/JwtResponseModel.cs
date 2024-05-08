namespace ECommerce.WebUI.Models
{
    public class JwtResponseModel
    {
        public string Token { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
