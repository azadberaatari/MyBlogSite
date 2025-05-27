using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Areas.Admin.Models;

namespace MyBlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]


    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();

            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 10
            });

            list.Add(new CategoryClass
            {
                categoryname = "Futbol",
                categorycount = 14
            });

            list.Add(new CategoryClass
            {
                categoryname = "Sinema",
                categorycount = 5
            });

            list.Add(new CategoryClass
            {
                categoryname = "Müzik",
                categorycount = 2
            });

            return Json(new { jsonlist = list });
        }
    }
}
