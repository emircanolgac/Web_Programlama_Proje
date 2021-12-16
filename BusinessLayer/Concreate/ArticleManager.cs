using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class ArticleManager : IArticleService
    {
        IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void ArticleAdd(Article article)
        {
            throw new NotImplementedException();
        }

        public void ArticleDelete(Article article)
        {
            throw new NotImplementedException();
        }

        public void ArticleUpdate(Article article)
        {
            throw new NotImplementedException();
        }

        public Article GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetList()
        {
            return _articleDal.GetListAll();
        }
    }
}
