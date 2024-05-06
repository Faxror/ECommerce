using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
