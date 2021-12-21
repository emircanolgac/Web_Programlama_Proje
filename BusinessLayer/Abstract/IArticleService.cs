using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article> 
    {
        List<Article> GetArticleListWithCategory();
        List<Article> GetArticleListByWriter(int id);

    }
}
