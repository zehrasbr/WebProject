using Microsoft.AspNetCore.Mvc;

namespace WebProject.ViewComponents.AppointmentComponents
{
    public class _AppointmentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
