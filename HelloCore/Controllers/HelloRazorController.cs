﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Controllers
{
    public class HelloRazorController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Hoi Razor";
            return View();
        }

        public IActionResult Hallo(string naam, int aantal)
        {
            ViewData["Message"] = "Hallo " + naam;
            ViewData["Aantal"] = aantal;
            return View();
        }
    }
}