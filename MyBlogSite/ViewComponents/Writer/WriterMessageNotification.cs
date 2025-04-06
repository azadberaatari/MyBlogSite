using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
