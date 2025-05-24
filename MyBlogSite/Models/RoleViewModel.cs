using System.ComponentModel.DataAnnotations;

namespace MyBlogSite.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage="lütfen rol adı giriniz")]
        public string name { get; set; }
    }
}
