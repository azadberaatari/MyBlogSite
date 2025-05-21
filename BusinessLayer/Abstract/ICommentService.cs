using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetList(int id);
        void CommentAdd(Comment comment);
        // void CategoryDelete(Comment category);
        // void CategoryUpdate(Comment category);
        //  Category GetByID(int id);
        List<Comment> GetCommentWithBlog();
    }
}
