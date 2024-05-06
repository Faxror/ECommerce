using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponontPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        }
    }
}
