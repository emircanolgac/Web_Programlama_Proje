using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Proje.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult partialAddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult partialAddComment(Comment  p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommenStatus = true;
            p.ArticleId = 19;
            cm.CommentAdd(p);
            return PartialView();
        }

        public PartialViewResult commentListByArticle(int id)
        {
            var values = cm.GetList(id);
            return PartialView(values);
        }

    }
}
