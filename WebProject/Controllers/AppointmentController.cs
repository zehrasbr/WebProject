using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System;
using System.Text.Json;
using WebProject.Models;
using WebProject.Context;

namespace WebProject.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly MyDbContext _context;

        public AppointmentController(MyDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Appointment model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

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
                return View(model);
            }
        }
    }
}
