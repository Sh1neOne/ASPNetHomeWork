﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Contacts()
        {
            
            return View();
        }

    }
}
