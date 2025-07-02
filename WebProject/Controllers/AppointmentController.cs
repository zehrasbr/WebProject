using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AppointmentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Appointment model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("zehra.isbir@cyberverse.com.tr", "RealRemoteLab");
                mail.To.Add("zehraisbr@gmail.com");

                mail.Subject = "Yeni Randevu Talebi";
                mail.IsBodyHtml = true;
                mail.Body = $@"
                <h2>Yeni Randevu Talebi</h2>
                <p><strong>Ad:</strong> {model.Name}</p>
                <p><strong>Soyad:</strong> {model.Surname}</p>
                <p><strong>Email:</strong> {model.Email}</p>
                <p><strong>Tarih:</strong> {model.DateTime}</p>
                <p><strong>Mesaj:</strong> {model.Message}</p>";

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("zehraisbr@gmail.com", "kwjlsoznkbtgmwyo"); 
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(mail);
                }

                TempData["Message"] = "Mesajınız başarıyla gönderildi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Mail gönderilirken hata oluştu: " + ex.Message);
                return View(model);
            }
        }
    }
}
