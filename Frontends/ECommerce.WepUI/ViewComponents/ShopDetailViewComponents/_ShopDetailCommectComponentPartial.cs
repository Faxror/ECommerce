using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.ShopDetailViewComponents
{
    public class _ShopDetailCommectComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
