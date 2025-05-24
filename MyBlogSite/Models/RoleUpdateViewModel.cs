using System.ComponentModel.DataAnnotations;

namespace MyBlogSite.Models
{
    public class RoleUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen rol adı giriniz.")]
        public string name { get; set; }
    }
}
