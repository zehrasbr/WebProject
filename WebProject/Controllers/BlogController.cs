using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
