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

        public List<Article> GetArticleListWithCategory()
        {
            return _articleDal.GetListWithCategory();
        }

        public List<Article> GetListWithCategoryByWriterBm(int id)
        {
            return _articleDal.GetListWithCategoryByWriter(id).ToList();
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetByID(id);
        }

        public List<Article> GetArticleByID(int id)
        {
            return _articleDal.GetListAll(x => x.ArticleId == id);
        }

        public List<Article> GetList()
        {
            return _articleDal.GetListAll();
        }

        public List<Article> GetLast3Article()
        {
            return _articleDal.GetListAll().Take(3).ToList();  
        }

        public List<Article> GetArticleListByWriter(int id)
        {
            return _articleDal.GetListAll(x => x.WriterID == id);
        }

        public void TAdd(Article t)
        {
            _articleDal.Insert(t);
        }

        public void TDelete(Article t)
        {
            _articleDal.Delete(t);
        }

        public void TUpdate(Article t)
        {
            _articleDal.Update(t);
        }

        public Article GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
