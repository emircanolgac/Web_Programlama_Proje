using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proje.Controllers
{
    public class ArticleController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        ArticleManager bm = new ArticleManager(new EfArticleRepository());
        Context c = new Context();

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
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(writerID);
            
            return View(values);
        }

        [HttpGet]
        public IActionResult ArticleAdd()
        {
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryID.ToString(),
                                                    }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult ArticleAdd(Article p)
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            ArticleValidator av = new ArticleValidator();
            ValidationResult results = av.Validate(p);
            if (results.IsValid)
            {
                p.ArticleStatus = true;
                p.ArticleCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
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

        public IActionResult DeleteArticle(int id)
        {
            var articleValue = bm.TGetById(id);
            bm.TDelete(articleValue);

            return RedirectToAction("ArticleListByWriter", "Article");
        }

        [HttpGet]
        public IActionResult EditArticle(int id)
        {
            var articleValue = bm.TGetById(id);
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(articleValue);
        }

        [HttpPost]
        public IActionResult EditArticle(Article p)
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            p.WriterID = writerID;
            p.ArticleCreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ArticleStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("ArticleListByWriter");
        }
    }
}
