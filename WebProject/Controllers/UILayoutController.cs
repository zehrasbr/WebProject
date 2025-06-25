using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
