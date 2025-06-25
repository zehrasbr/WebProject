using Microsoft.AspNetCore.Mvc;

namespace WebProject.ViewComponents.DefaultComponents
{
    public class _DefaultSkillsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
