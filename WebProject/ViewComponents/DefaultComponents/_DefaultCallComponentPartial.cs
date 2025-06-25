using Microsoft.AspNetCore.Mvc;

namespace WebProject.ViewComponents.DefaultComponents
{
    public class _DefaultCallComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
