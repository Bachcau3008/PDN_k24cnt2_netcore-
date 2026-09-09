using Microsoft.AspNetCore.Mvc;
using PdnLesson06.Models;


namespace PdnLesson06.ViewComponents 
{
    public class CategoryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int? n)
        {
            List<Category> categories = new List<Models.Category>
            {
                new Models.Category { CategoryId = 1, CategoryName = "Electronics", IsActive = true },
                new Models.Category { CategoryId = 2, CategoryName = "Books", IsActive = true },
                new Models.Category { CategoryId = 3, CategoryName = "Clothing", IsActive = false },
                new Models.Category { CategoryId = 4, CategoryName = "Home & Kitchen", IsActive = true }
            };

            n = n ?? 0;
            var search = categories.Where(c => c.CategoryId >n).ToList();
            return View(search);
        }
    }
}
