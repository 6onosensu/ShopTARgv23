﻿using Microsoft.AspNetCore.Mvc;

namespace ShopTARgv23.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
