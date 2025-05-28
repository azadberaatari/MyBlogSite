using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyBlogSite.Controllers
{
    [AllowAnonymous]

    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

        [AllowAnonymous]
        private int EnsureWriterID()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writer = c.Writers.FirstOrDefault(x => x.WriterMail == usermail);

            if (writer == null)
            {
                writer = new Writer
                {
                    WriterMail = usermail,
                    WriterName = "Varsayılan Yazar",
                    WriterAbout = "Identity ile oluşturuldu",
                    WriterImage = "default.jpg",
                    WriterStatus = true,
                    WriterPassword = "123456" // gerçekte hashlenmeli!
                };

                c.Writers.Add(writer);
                c.SaveChanges();
            }

            return writer.WriterID;
        }

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            ViewBag.BlogID = id; // ← Burası kritik! PartialAddComment kullanabilsin diye eklenir
            var values = bm.GetBlogByID(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
        //[HttpPost]
        //public IActionResult BlogAdd(Blog p)
        //{
        //    var username = User.Identity.Name;
        //    var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
        //    var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();


        //    BlogValidator bv = new BlogValidator();
        //    ValidationResult result = bv.Validate(p);
        //    if (result.IsValid)
        //    {
        //        p.BlogStatus = true;
        //        p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        //        p.WriterID = writerID;
        //        bm.TAdd(p);
        //        return RedirectToAction("BlogListByWriter", "Blog");
        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();
        //}
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            int writerID = EnsureWriterID(); // 👍 kritik kısım burası

            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(p);

            if (result.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                // Form hata durumunda kategori listesi tekrar yollanmalı
                ViewBag.cv = cm.GetList().Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                }).ToList();

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View();
            }
        }


        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            p.WriterID = writerID;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }

    }   
}
