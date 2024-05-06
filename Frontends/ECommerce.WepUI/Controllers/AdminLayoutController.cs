using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
