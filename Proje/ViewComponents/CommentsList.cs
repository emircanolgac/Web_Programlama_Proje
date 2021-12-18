using Microsoft.AspNetCore.Mvc;
using Proje.Models;
using System.Collections.Generic;

namespace Proje.ViewComponents
{
    public class CommentsList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1,
                    Username = "Emir"
                },
                new UserComment {
                    ID = 2,
                    Username = "Can"
                },
                new UserComment
                {
                    ID=3,
                    Username ="Gamze"
                }
            };
            return View(commentValues);  
        }
    }
}
