using Microsoft.AspNetCore.Mvc;

namespace WebProject.ViewComponents.BlogComponents
{
    public class _BlogDetailsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
