﻿//using BusinessLayer.Concrete;
//using DataAccessLayer.EntityFramework;
//using EntityLayer.Concrete;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace MyBlogSite.Controllers
//{
//    [AllowAnonymous]
//    public class CommentController : Controller
//    {
//        CommentManager cm = new CommentManager(new EfCommentRepository());
//        public IActionResult Index()
//        {
//            return View();
//        }
//        [HttpGet]
//        public PartialViewResult PartialAddComment()
//        {
//            return PartialView();
//        }
//        [HttpPost]
//        public PartialViewResult PartialAddComment(Comment p)
//        {
//            p.CommentDate = DateTime.Now;
//            p.CommentStatus = true;

//            // p.BlogID zaten formdan geliyor
//            cm.CommentAdd(p);

//            return PartialView();

//        }

//        public PartialViewResult CommentListByBlog(int id)
//        {
//            var values = cm.GetList(id);
//            return PartialView(values);
//        }
//    }
//}





using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult PartialAddComment(Comment p)
        {
            p.CommentDate = DateTime.Now;
            p.CommentStatus = true;
            cm.CommentAdd(p);
            return Ok(); // AJAX ile başarılı dönüş
        }

        public PartialViewResult CommentListByBlog(int id)
        {
            var values = cm.GetList(id);
            return PartialView(values);
        }
    }
}


