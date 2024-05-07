using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.ShopViewComponents
{
    public class _ShopDefaultComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
