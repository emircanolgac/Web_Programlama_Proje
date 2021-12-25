using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Proje.Areas.Admin.Models;
using System.Collections.Generic;
using System.IO;

namespace Proje.Areas.Admin.Controllers
{
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
                    worksheet.Cell(ArticleRowCount,1).Value = item.ID;
                    worksheet.Cell(ArticleRowCount, 2).Value = item.ArticleName;
                    ArticleRowCount++;
                }

                using (var stream=new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats - officedocument.spreadsheetml.sheet", "Deneme_1.xlsx");
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
    }
}
