﻿using Microsoft.AspNetCore.Mvc;

namespace ProniaTask.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

    }
}
