using System.ComponentModel.DataAnnotations;

namespace MyBlogSite.Models
{
    public class BlogIdeaViewModel
    {
        [Required(ErrorMessage = "Konu boş bırakılamaz!")]
        [Display(Name = "Blog Konusu")]
        public string Topic { get; set; }

        [Display(Name = "Özel Talimatlar (Opsiyonel)")]
        public string CustomPrompt { get; set; }

        [Display(Name = "Özel Prompt Kullan")]
        public bool UseCustomPrompt { get; set; }

        public string GeneratedContent { get; set; }
        public bool IsGenerated { get; set; }
    }
}