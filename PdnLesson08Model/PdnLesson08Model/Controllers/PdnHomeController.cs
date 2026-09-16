using Microsoft.AspNetCore.Mvc;
using PdnLesson08Model.Models;
using System.Diagnostics;

namespace PdnLesson08Model.Controllers
{
    public class PdnHomeController : Controller
    {
        public IActionResult PdnIndex()
        {
            return View();
        }

        public IActionResult PdnPrivacy()
        {
            return View();
        }
        public IActionResult PdnAbout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
