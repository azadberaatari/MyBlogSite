using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
