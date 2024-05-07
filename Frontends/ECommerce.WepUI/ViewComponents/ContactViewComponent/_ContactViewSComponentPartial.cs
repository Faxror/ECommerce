using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.ContactViewComponent
{
    public class _ContactViewSComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
