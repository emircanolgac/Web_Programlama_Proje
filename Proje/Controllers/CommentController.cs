using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Proje.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult partialAddComment()
        {
            return PartialView();
        }

        public PartialViewResult commentListByArticle(int id)
        {
            var values = cm.GetList(id);
            return PartialView(values);
        }

    }
}
