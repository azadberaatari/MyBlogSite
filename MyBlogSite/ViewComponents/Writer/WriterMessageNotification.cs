using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            string p;
            p = "azad@gmail.com";
            var values = mm.GetInboxListByWriter(p);
            return View(values);
        }
    }
}
