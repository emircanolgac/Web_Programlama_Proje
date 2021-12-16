using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IArticleService
    {
        void ArticleAdd(Article article);
        void ArticleDelete(Article article);
        void ArticleUpdate(Article article);
        List<Article> GetList();
        Article GetByID(int id);
    }
}
