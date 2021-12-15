using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ArticleRepository : IArticleDal
    {
        public void AddArticle(Article article)
        {
            using var c = new Context();
            c.Add(article);
            c.SaveChanges();

        }

        public void Delete(Article item)
        {
            throw new NotImplementedException();
        }

        public void DeleteArticle(Article article)
        {
            using var c = new Context();
            c.Remove(article);
            c.SaveChanges();
        }

        public Article GetById(int id)
        {
            using var c = new Context();
            return c.Articles.Find(id);
        }

        public Article GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Article item)
        {
            throw new NotImplementedException();
        }

        public List<Article> ListAllArticle()
        {
            using var c = new Context();
            return c.Articles.ToList();
        }

        public void Update(Article item)
        {
            throw new NotImplementedException();
        }

        public void UpdateArticle(Article article)
        {
            using var c = new Context();
            c.Update(article);
            c.SaveChanges();
        }
    }
}
