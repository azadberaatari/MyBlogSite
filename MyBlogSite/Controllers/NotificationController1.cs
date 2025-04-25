using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.Controllers
{
    public class NotificationController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
