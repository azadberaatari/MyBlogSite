﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class WidgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
