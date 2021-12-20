using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Proje.ViewComponents.Article
{
    public class WriterLastArticle : ViewComponent
    {
        ArticleManager am = new ArticleManager(new EfArticleRepository());

        public IViewComponentResult Invoke()
        {
            var values = am.GetArticleListByWriter(1);
            return View(values);
        }

    }
}
