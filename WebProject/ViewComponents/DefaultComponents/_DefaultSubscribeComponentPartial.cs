using Microsoft.AspNetCore.Mvc;

namespace WebProject.ViewComponents.DefaultComponents
{
    public class _DefaultSubscribeComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
