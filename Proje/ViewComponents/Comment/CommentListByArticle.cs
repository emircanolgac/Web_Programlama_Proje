using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Proje.ViewComponents.Comment
{
    public class CommentListByArticle : ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentRepository()) ;
        public IViewComponentResult Invoke()
        {
            var values = cm.GetList(23);
            return View(values);
        }
    }
}
