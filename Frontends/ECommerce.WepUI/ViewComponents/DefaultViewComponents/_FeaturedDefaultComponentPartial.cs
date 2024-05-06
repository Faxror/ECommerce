using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class FeaturedDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
