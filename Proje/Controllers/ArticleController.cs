using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Proje.Controllers
{
    public class ArticleController : Controller
    {
        ArticleManager bm = new ArticleManager(new EfArticleRepository());
        public IActionResult Index()
        {
            var values = bm.GetArticleListWithCategory();
            return View(values);
        }

        public IActionResult ArticleReadAll(int id)
        {
            var values = bm.GetArticleByID(id);
            return View(values); 
        }
    }
}
