using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Proje.ViewComponents.Article
{
    public class ArticleListDashboard : ViewComponent
    {
        ArticleManager am = new ArticleManager(new EfArticleRepository());

        public IViewComponentResult Invoke()
        {
            var values = am.GetArticleListWithCategory();
            return View(values);
        }
    }
}
