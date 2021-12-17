using Microsoft.AspNetCore.Mvc;

namespace Proje.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult partialAddComment()
        {
            return PartialView();
        }

        public PartialViewResult commentListByArticle()
        {
            return PartialView();
        }

    }
}
