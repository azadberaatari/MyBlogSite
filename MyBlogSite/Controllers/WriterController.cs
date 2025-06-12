using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Models;
using System.ComponentModel.DataAnnotations;

namespace MyBlogSite.Controllers
{
    public class WriterController : Controller
    {
        UserManager userManager = new UserManager(new EfUserRepository());
        WriterManager wm = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;
        private readonly OpenAiService _openAiService;

        public WriterController(UserManager<AppUser> userManager, OpenAiService openAiService)
        {
            _userManager = userManager;
            _openAiService = openAiService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            Context c = new Context();
            var writername = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writername.FirstOrDefault();  
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.namesurname = values.NameSurname;
            model.username = values.UserName;
            model.imageurl = values.ImageUrl;
            model.mail = values.Email;

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.Email = model.mail;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p )
        {
            Writer w = new Writer();
            if (p.WriterImage!= null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterName = p.WriterName;
            w.WriterAbout = p.WriterAbout;
            w.WriterMail = p.WriterMail;
            w.WriterStatus = true;
            w.WriterPassword = p.WriterPassword;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult BlogFikri()
        {
            return View(new BlogIdeaViewModel()); // Model kullanarak daha temiz bir yaklaşım
        }

        [HttpPost]
        public async Task<IActionResult> BlogFikri(BlogIdeaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Özel prompt kullanımı (opsiyonel)
                var customPrompt = model.UseCustomPrompt
                    ? $"Konu: {model.Topic}\n\nTalimatlar: {model.CustomPrompt}\n\nYazı:"
                    : null;

                var generatedContent = await _openAiService.GenerateBlogContentAsync(model.Topic, customPrompt);

                model.GeneratedContent = generatedContent;
                model.IsGenerated = true;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Bir hata oluştu: {ex.Message}");
            }

            return View(model);
        }
    }
}

