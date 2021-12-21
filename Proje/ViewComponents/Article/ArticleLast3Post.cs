using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Proje.ViewComponents.Article
{
    public class ArticleLast3Post : ViewComponent
    {
        ArticleManager am = new ArticleManager(new EfArticleRepository());

        public IViewComponentResult Invoke()
        {
            var values = am.GetLast3Article();
            return View(values);
        }
    }
}
