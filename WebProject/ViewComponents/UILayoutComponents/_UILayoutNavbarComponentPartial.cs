using Microsoft.AspNetCore.Mvc;

namespace WebProject.ViewComponents.UILayoutComponents
{
    public class _UILayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
