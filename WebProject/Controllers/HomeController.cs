using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult Index()
        {
            return View(GetScheduleData());
        }
        public List<AppointmentData> GetScheduleData()
        {
            List<AppointmentData> appData = new List<AppointmentData>();
            appData.Add(new AppointmentData
            { Id = 1, Subject = "Explosion of Betelgeuse Star", StartTime = new DateTime(2022, 2, 11, 9, 30, 0), EndTime = new DateTime(2022, 2, 11, 11, 0, 0) });
            appData.Add(new AppointmentData
            { Id = 2, Subject = "Thule Air Crash Report", StartTime = new DateTime(2022, 2, 12, 12, 0, 0), EndTime = new DateTime(2022, 2, 12, 14, 0, 0) });
            appData.Add(new AppointmentData
            { Id = 3, Subject = "Blue Moon Eclipse", StartTime = new DateTime(2022, 2, 13, 9, 30, 0), EndTime = new DateTime(2022, 2, 13, 11, 0, 0) });
            appData.Add(new AppointmentData
            { Id = 4, Subject = "Meteor Showers in 2018", StartTime = new DateTime(2022, 2, 14, 13, 0, 0), EndTime = new DateTime(2022, 2, 14, 14, 30, 0) });
            appData.Add(new AppointmentData
            { Id = 5, Subject = "Milky Way as Melting pot", StartTime = new DateTime(2022, 2, 15, 12, 0, 0), EndTime = new DateTime(2022, 2, 15, 14, 0, 0) });
            return appData;
        }
    }
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}