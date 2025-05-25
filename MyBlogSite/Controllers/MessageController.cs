using DataAccessLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MyBlogSite.Controllers
{

    public class MessageController : Controller
    {
        
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        public IActionResult InBox()
        {

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();


            var values = mm.GetInboxListByWriter(writerID);
            return View(values);
        }
        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            var values = mm.GetSendBoxListByWriter(writerID);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetById(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            var writers = c.Writers.Select(x => new SelectListItem
            {
                Text = x.WriterName, // Dropdown'da görünecek isim
                Value = x.WriterID.ToString() // Seçilen değer: ReceiverID olacak
            }).ToList();

            ViewBag.WriterList = writers; // View'da kullanacağız
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 message)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            message.SenderID = writerID;
            message.MessageDate = DateTime.Now;
            message.MessageStatus = true;

            mm.TAdd(message);
            return RedirectToAction("SendBox");
        }


    }
}
