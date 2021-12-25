using DataAccessLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Proje.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Articles.OrderByDescending(x=>x.ArticleId).Select(x=>x.ArticleTitle).Take(1).FirstOrDefault();
            ViewBag.v3 = c.Comments.Count();
            return View();
        }
    }
}
