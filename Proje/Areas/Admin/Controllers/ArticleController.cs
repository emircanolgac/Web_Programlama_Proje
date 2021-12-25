using ClosedXML.Excel;
using DataAccessLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Proje.Areas.Admin.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        public IActionResult ExportStaticExcelArticleList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Makale Listesi");
                worksheet.Cell(1, 1).Value = "Makale ID";
                worksheet.Cell(1, 2).Value = "Makale Adı";

                int ArticleRowCount = 2;
                foreach (var item in GetArticleList())
                {
                    worksheet.Cell(ArticleRowCount, 1).Value = item.ID;
                    worksheet.Cell(ArticleRowCount, 2).Value = item.ArticleName;
                    ArticleRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Deneme_1.xlsx");
                }
            }
        }

        public List<ArticleModel> GetArticleList()
        {
            List<ArticleModel> am = new List<ArticleModel>
            {
                new ArticleModel {ID=1, ArticleName="Kuyruklu Yıldız Nedir?"},
                new ArticleModel {ID=2, ArticleName="Uydu Nedir?"},
                new ArticleModel {ID=3, ArticleName="Kütle Çekim Kuvveti Nedir?"}
            };
            return am;
        }

        public IActionResult ArticleListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelArticleList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Makale Listesi");
                worksheet.Cell(1, 1).Value = "Makale ID";
                worksheet.Cell(1, 2).Value = "Makale Adı";

                int ArticleRowCount = 2;
                foreach (var item in ArticleTitleList())
                {
                    worksheet.Cell(ArticleRowCount, 1).Value = item.ID;
                    worksheet.Cell(ArticleRowCount, 2).Value = item.ArticleName;
                    ArticleRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Deneme_1.xlsx");
                }
            }
        }

        public List<ArticleModel2> ArticleTitleList()
        {
            List<ArticleModel2> bm = new List<ArticleModel2>();
            using (var c = new Context())
            {
                bm = c.Articles.Select(x => new ArticleModel2
                {
                    ID = x.ArticleId,
                    ArticleName = x.ArticleTitle
                }).ToList();
            }

            return bm;
        }

        public IActionResult ArticleTitleListExcel()
        {
            return View();  
        }
    }
}
