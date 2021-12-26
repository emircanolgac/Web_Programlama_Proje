using DataAccessLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Proje.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.v1 = c.Articles.Count().ToString();
            ViewBag.v2 = c.Articles.Where(x=>x.WriterID==1).Count().ToString();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
