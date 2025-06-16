using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Areas.Admin.Models;
using Newtonsoft.Json;

namespace MyBlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterByID(int writerid)
        {
            var findwriter = writers.FirstOrDefault(x => x.ID == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findwriter);
            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass writerClass)
        {
            writers.Add(writerClass);
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.ID == id);
            writers.Remove(writer);

            return Json(writer); //?
        }

        public IActionResult UpdateWriter(WriterClass writerClass)
        {
            var writer = writers.FirstOrDefault(x => x.ID == writerClass.ID);
            writer.Name = writerClass.Name;
            var jsonWriter = JsonConvert.SerializeObject(writerClass);
            return Json(jsonWriter);

        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                ID = 1,
                Name="Farit"
            },
            new WriterClass
            {
                ID = 2,
                Name="Recep"
            },
            new WriterClass
            {
                ID = 3,
                Name="Kayra"
            },
            new WriterClass
            {
                ID = 4,
                Name="Mesut"
            },
            new WriterClass
            {
                ID = 5,
                Name="Emine"
            },
            new WriterClass
            {
                ID = 6,
                Name="Ersan"
            },
            new WriterClass
            {
                ID = 7,
                Name="Azad"
            },
        };
    }
}

