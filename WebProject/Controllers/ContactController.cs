using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Email model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("zehra.isbir@cyberverse.com.tr", "RealRemoteLab");
                mailMessage.To.Add("zehraisbr@gmail.com");
                mailMessage.Subject = model.Subject;
                mailMessage.Body = $@"
    <html>
        <body style=""font-family: Arial, sans-serif; font-size: 14px; color: #333;"">
            <h2>RealRemoteLab İletişim Mesajı</h2>
            <table style=""width: 100%; border-collapse: collapse;"">
                <tr>
                    <td style=""padding: 8px; border: 1px solid #ddd;""><strong>Gönderen Ad Soyad:</strong></td>
                    <td style=""padding: 8px; border: 1px solid #ddd;"">{model.Name}</td>
                </tr>
                <tr>
                    <td style=""padding: 8px; border: 1px solid #ddd;""><strong>Mail Adresi:</strong></td>
                    <td style=""padding: 8px; border: 1px solid #ddd;"">{model.Mail}</td>
                </tr>
                <tr>
                    <td style=""padding: 8px; border: 1px solid #ddd;""><strong>Konu:</strong></td>
                    <td style=""padding: 8px; border: 1px solid #ddd;"">{model.Subject}</td>
                </tr>   
                <tr>
                    <td style=""padding: 8px; border: 1px solid #ddd;""><strong>Konu Tipi:</strong></td>
                    <td style=""padding: 8px; border: 1px solid #ddd;"">{model.SubjectType}</td>
                </tr>
                <tr>
                    <td style=""padding: 8px; border: 1px solid #ddd;""><strong>Açıklama:</strong></td>
                    <td style=""padding: 8px; border: 1px solid #ddd;"">{model.Description}</td>
                </tr>
            </table>
        </body>
    </html>
";
                mailMessage.IsBodyHtml = true;
                //mailMessage.IsBodyHtml = false;

                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new NetworkCredential("zehraisbr@gmail.com", "kwjlsoznkbtgmwyo");
                    smtpClient.EnableSsl = true;

                    await smtpClient.SendMailAsync(mailMessage);
                }

                TempData["Message"] = "Mesajınız gönderildi.";
                ModelState.Clear();
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

