﻿using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
