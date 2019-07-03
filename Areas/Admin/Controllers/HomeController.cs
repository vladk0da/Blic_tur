using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Blic_tur.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController: Controller
    {
        private readonly IHostingEnvironment he;
        public HomeController(IHostingEnvironment e)
        {
            he = e;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult ShowFields( IFormFile picture) // Сюда мы передаём параметры, которые применятся к странице /Admin/Home/ShowFields
        {
            if(picture !=null)
            {
                var fileName = Path.Combine(he.WebRootPath, Path.GetFileName(picture.FileName));
                picture.CopyTo(new FileStream(fileName, FileMode.Create));
                ViewData["fileLocation"] = "/"+Path.GetFileName(picture.FileName);
            }

            return View();
        }
    }
}
