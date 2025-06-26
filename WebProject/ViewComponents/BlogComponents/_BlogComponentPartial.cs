using Microsoft.AspNetCore.Mvc;

namespace WebProject.ViewComponents.BlogComponents
{
    public class _BlogComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
