using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Proje.Controllers
{
    [AllowAnonymous]
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
            ViewBag.Id = id;
            var values = bm.GetArticleByID(id);
            return View(values); 
        }

        public IActionResult ArticleListByWriter()
        {
            var values = bm.GetArticleListByWriter(1);
            
            return View(values);
        }

        [HttpGet]
        public IActionResult ArticleAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ArticleAdd(Article p)
        {
            ArticleValidator av = new ArticleValidator();
            ValidationResult results = av.Validate(p);
            if (results.IsValid)
            {
                p.ArticleStatus = true;
                p.ArticleCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = 1;
                bm.TAdd(p);
                return RedirectToAction("ArticleListByWriter", "Article");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}
