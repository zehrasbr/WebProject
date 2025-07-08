using Microsoft.AspNetCore.Mvc;

namespace WebProject.ViewComponents.AppointmentComponents
{
    public class _AppointmentScheduleComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
