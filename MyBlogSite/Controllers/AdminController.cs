using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
