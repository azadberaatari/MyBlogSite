using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Models;

namespace MyBlogSite.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
                    UserName="azad"
                },
                new UserComment
                {
                    ID=2,
                    UserName="Murat"
                },
                new UserComment
                {
                    ID=3,
                    UserName="Merve"
                },
            };
            return View(commentvalues);
        }
    }
}
