using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
