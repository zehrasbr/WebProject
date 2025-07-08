using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System;
using System.Text.Json;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AppointmentController : Controller
    {
        private static Dictionary<string, List<string>> bookedSlots = new Dictionary<string, List<string>>
        {
            { "2025-07-08", new List<string> { "09:00", "14:00" } },
            { "2025-07-09", new List<string> { "11:00", "15:00", "16:00" } }
        };

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["BookedSlotsJson"] = JsonSerializer.Serialize(bookedSlots);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Appointment model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["BookedSlotsJson"] = JsonSerializer.Serialize(bookedSlots);
                return View(model);
            }

            if (string.IsNullOrEmpty(model.DateTime) || model.DateTime.Length < 16)
            {
                ModelState.AddModelError("DateTime", "Lütfen geçerli bir tarih ve saat seçiniz.");
                ViewData["BookedSlotsJson"] = JsonSerializer.Serialize(bookedSlots);
                return View(model);
            }

            string date = model.DateTime.Substring(0, 10);
            string hour = model.DateTime.Substring(11, 5);

            if (bookedSlots.ContainsKey(date) && bookedSlots[date].Contains(hour))
            {
                ModelState.AddModelError("DateTime", "Seçilen tarih ve saat dolu, lütfen başka bir zaman seçiniz.");
                ViewData["BookedSlotsJson"] = JsonSerializer.Serialize(bookedSlots);
                return View(model);
            }

            if (!bookedSlots.ContainsKey(date))
                bookedSlots[date] = new List<string>();

            bookedSlots[date].Add(hour);

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("zehra.isbir@cyberverse.com.tr", "RealRemoteLab");
                mail.To.Add("zehraisbr@gmail.com");
                mail.Subject = "Yeni Randevu Talebi";
                mail.IsBodyHtml = true;
                mail.Body = $@"
<html>
    <body style=""font-family: Arial, sans-serif; font-size: 14px; color: #333;"">
        <h2>Yeni Randevu Talebi</h2>
        <table style=""width: 100%; border-collapse: collapse;"">
            <tr><td style=""padding: 8px; border: 1px solid #ddd;""><strong>Ad:</strong></td><td style=""padding: 8px; border: 1px solid #ddd;"">{model.Name}</td></tr>
            <tr><td style=""padding: 8px; border: 1px solid #ddd;""><strong>Soyad:</strong></td><td style=""padding: 8px; border: 1px solid #ddd;"">{model.Surname}</td></tr>
            <tr><td style=""padding: 8px; border: 1px solid #ddd;""><strong>Email:</strong></td><td style=""padding: 8px; border: 1px solid #ddd;"">{model.Email}</td></tr>
            <tr><td style=""padding: 8px; border: 1px solid #ddd;""><strong>Tarih:</strong></td><td style=""padding: 8px; border: 1px solid #ddd;"">{model.DateTime}</td></tr>
            <tr><td colspan=""2"" style=""padding: 8px; border: 1px solid #ddd;""><strong>Mesaj:</strong><br/><div style=""white-space: pre-wrap;"">{model.Message}</div></td></tr>
        </table>
    </body>
</html>";

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
                ViewData["BookedSlotsJson"] = JsonSerializer.Serialize(bookedSlots);
                return View(model);
            }
        }
    }
}
