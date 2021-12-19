using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace Proje.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer p)
        {
            p.WriterStatus = true;
            p.WriterAbout = "deneme test";
            wm.WriterAdd(p);
            return RedirectToAction("Index", "Article");
        }
    }
}
