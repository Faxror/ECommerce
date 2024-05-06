using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _ProductsSDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
