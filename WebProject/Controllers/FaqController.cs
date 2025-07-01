using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class FaqController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
