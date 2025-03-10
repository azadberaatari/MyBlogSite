using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
