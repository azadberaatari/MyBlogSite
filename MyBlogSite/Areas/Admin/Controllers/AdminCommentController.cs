using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminCommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            var values = cm.GetCommentWithBlog();
            return View(values);
        }
    }
}
