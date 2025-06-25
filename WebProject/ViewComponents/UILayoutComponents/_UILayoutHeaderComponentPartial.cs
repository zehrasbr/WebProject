using Microsoft.AspNetCore.Mvc;

namespace WebProject.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
