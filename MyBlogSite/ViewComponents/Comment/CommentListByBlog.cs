﻿//using BusinessLayer.Concrete;
//using DataAccessLayer.EntityFramework;
//using Microsoft.AspNetCore.Mvc;

//namespace MyBlogSite.ViewComponents.Comment
//{
//    public class CommentListByBlog : ViewComponent
//    {
//        CommentManager cm = new CommentManager(new EfCommentRepository());
//        public IViewComponentResult Invoke(int id)
//        {
//            var values = cm.GetList(id);
//            return View(values);
//        }
//    }
//}



using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());

        public IViewComponentResult Invoke(int id)
        {
            var values = cm.GetList(id);
            return View(values);
        }
    }
}

