using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutCoponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
