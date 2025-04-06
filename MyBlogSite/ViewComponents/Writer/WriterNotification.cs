using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
