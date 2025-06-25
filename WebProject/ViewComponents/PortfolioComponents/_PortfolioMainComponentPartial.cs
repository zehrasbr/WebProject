using Microsoft.AspNetCore.Mvc;

namespace WebProject.ViewComponents.PortfolioComponents
{
    public class _PortfolioMainComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
