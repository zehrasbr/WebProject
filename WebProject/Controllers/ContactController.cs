using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Email model)
        {
            MailMessage mailim = new MailMessage();
            mailim.To.Add("zehraisbr@gmail.com");
            mailim.From = new MailAddress("zehraisbr@gmail.com");
            mailim.Subject = "RealRemoteLab Sayfasından Mesajınız Var. " + model.Subject;
            mailim.Body = "Sayın yetkili, " + model.Name + " kişisinden gelen mesajın içeriği aşağıdaki gibidir. <br>" + model.Description;
            mailim.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("zehraisbr@gmail.com", "pqghrzgqpoqnpykk");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            return View(mailim);
        }

    }
}
