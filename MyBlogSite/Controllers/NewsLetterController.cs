using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLatter p)
        {
            p.MailStatus = true;
            nm.AddNewsLetter(p);
            return PartialView();
        }
    }
}
