using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class CultureController : Controller
    {
        [HttpGet]
        public IActionResult SetCulture(string culture)
        {
            if (!string.IsNullOrEmpty(culture))
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddYears(1),
                        IsEssential = true
                    });
            }

            string referer = Request.Headers["Referer"];
            return Redirect(!string.IsNullOrWhiteSpace(referer) ? referer : "/");
        }
    }
}
