using Microsoft.AspNetCore.Mvc;

namespace WebProject.ViewComponents.DefaultComponents
{
    public class _DefaultPortfolioComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
