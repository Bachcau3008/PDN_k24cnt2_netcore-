using Microsoft.AspNetCore.Mvc;

namespace PdnLessonLayout.Controllers
{
    public class PdnProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search(string keyword)
        {
            ViewData["Keyword"] = keyword;
            return View();
        }
        public IActionResult Hots()
        {
            return View();
        }
    }
}
