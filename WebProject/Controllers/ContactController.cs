﻿using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
