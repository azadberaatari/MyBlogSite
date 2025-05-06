using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
