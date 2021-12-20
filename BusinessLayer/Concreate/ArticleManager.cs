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

        public List<Article> GetArticleListWithCategory()
        {
            return _articleDal.GetListWithCategory();
        }

        public Article GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticleByID(int id)
        {
            return _articleDal.GetListAll(x => x.ArticleId == id);
        }

        public List<Article> GetList()
        {
            return _articleDal.GetListAll();
        }

        public List<Article> GetArticleListByWriter(int id)
        {
            return _articleDal.GetListAll(x => x.WriterID == id);
        }
    }
}
