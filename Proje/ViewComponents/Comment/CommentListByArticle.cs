using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Proje.ViewComponents.Comment
{
    public class CommentListByArticle : ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentRepository()) ;
        public IViewComponentResult Invoke(int id)
        {
            var values = cm.GetList(id);
            return View(values);
        }
    }
}
