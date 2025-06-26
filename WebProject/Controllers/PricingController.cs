using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class PricingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
