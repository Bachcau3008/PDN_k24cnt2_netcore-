using Microsoft.AspNetCore.Mvc;
using Pdn_lesson02_theory.Models;

namespace Pdn_lesson02_theory.Controllers
{
    public class PdnProductController : Controller
    {
        public IActionResult PdnIndex()
        {   
            ViewBag.name = "Phạm Đình Nguyên";
            ViewData["productVD"] = "Laptop Asus ";
            TempData["UNI"] = "Trường Đại học Nguyễn Trãi - NTU";

            return View();
        }
        public IActionResult GetProduct()
        {
            PdnProduct pdnProduct = new PdnProduct()
            {
                ProductID = "2410900057",
                ProductName = "Phạm Đình Nguyên",
                YearRelease = 2006,
                Price = 300006
            };
            
            ViewBag.product = pdnProduct;
            ViewData["product"] = pdnProduct;

            return View("product");
        }
    }
}
