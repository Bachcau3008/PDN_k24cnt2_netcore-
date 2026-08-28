using Microsoft.AspNetCore.Mvc;
using Pdn_lesson03.Models;

namespace Pdn_lesson03.Controllers
{
    public class PdnProductController : Controller
    {
        private readonly List<PdnProduct> _products = new()
        { 
            new PdnProduct { PdnProductId = "PDN001", PdnProductName = "Laptop Dell XPS 13", PdnYearRelease = 2023, PdnPrice = 25990000m },
            new PdnProduct { PdnProductId = "PDN002", PdnProductName = "MacBook Pro 14 M3", PdnYearRelease = 2024, PdnPrice = 39990000m },
            new PdnProduct { PdnProductId = "PDN003", PdnProductName = "iPhone 15 Pro Max", PdnYearRelease = 2023, PdnPrice = 29490000m },
            new PdnProduct { PdnProductId = "PDN004", PdnProductName = "Samsung Galaxy S24 Ultra", PdnYearRelease = 2024, PdnPrice = 27990000m },
            new PdnProduct { PdnProductId = "PDN005", PdnProductName = "iPad Air 5 M1", PdnYearRelease = 2022, PdnPrice = 14290000m },
            new PdnProduct { PdnProductId = "PDN006", PdnProductName = "Tai nghe Sony WH-1000XM5", PdnYearRelease = 2022, PdnPrice = 6990000m },
            new PdnProduct { PdnProductId = "PDN007", PdnProductName = "Màn hình LG UltraGear 27 inch", PdnYearRelease = 2023, PdnPrice = 8500000m },
            new PdnProduct { PdnProductId = "PDN008", PdnProductName = "Bàn phím cơ Keychron K2 V2", PdnYearRelease = 2021, PdnPrice = 1950000m },
            new PdnProduct { PdnProductId = "PDN009", PdnProductName = "Chuột Logitech MX Master 3S", PdnYearRelease = 2022, PdnPrice = 2450000m },
            new PdnProduct { PdnProductId = "PDN010", PdnProductName = "Đồng hồ Apple Watch Series 9", PdnYearRelease = 2023, PdnPrice = 9890000m }
            
        };



        public IActionResult Index()
        {
            return Json(_products);
        }
        public IActionResult PdnAllGetProduct() 
        {
            ViewData["Products"] = _products;
            return View();
        }
    }
}
