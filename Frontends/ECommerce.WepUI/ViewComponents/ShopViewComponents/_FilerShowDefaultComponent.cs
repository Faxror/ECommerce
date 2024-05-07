using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.ShopViewComponents
{
    public class _FilerShowDefaultComponent : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
