using Microsoft.AspNetCore.Mvc;

namespace Proje.Views.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
