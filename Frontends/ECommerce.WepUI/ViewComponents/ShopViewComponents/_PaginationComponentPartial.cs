using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.ShopViewComponents
{
    public class _PaginationComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
