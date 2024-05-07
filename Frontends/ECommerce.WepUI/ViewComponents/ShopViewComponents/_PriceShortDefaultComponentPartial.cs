using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.ShopViewComponents
{
    public class _PriceShortDefaultComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
