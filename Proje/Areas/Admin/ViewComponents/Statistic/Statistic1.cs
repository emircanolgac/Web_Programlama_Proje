using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Proje.Areas.Admin.ViewComponents.Statistic 
{
    public class Statistic1 : ViewComponent
    {
        ArticleManager am = new ArticleManager(new EfArticleRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = am.GetList().Count();
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();
            return View();
        } 
    }
}
        