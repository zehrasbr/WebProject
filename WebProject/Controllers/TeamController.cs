﻿using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
