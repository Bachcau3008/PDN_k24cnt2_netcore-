using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdnLesson12.Models;
using PdnLesson12.PdnEntities;

namespace PdnLesson12.Controllers
{
    public class PdnCategoriesController : Controller
    {
        private readonly PdnAppDbContext _context;

        public PdnCategoriesController(PdnAppDbContext context)
        {
            _context = context;
        }

        // GET: PdnCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: PdnCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdncategory = await _context.Categories
                .FirstOrDefaultAsync(m => m.PdnId == id);
            if (pdncategory == null)
            {
                return NotFound();
            }

            return View(pdncategory);
        }

        // GET: PdnCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PdnCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PdnId,PdnName,PdnStatus,CreatedDate")] PdnCategory pdncategory)
        {
            if (ModelState.IsValid)
            {
                pdncategory.CreatedDate = DateTime.Now;
                _context.Add(pdncategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pdncategory);
        }

        // GET: PdnCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdncategory = await _context.Categories.FindAsync(id);
            if (pdncategory == null)
            {
                return NotFound();
            }
            return View(pdncategory);
        }

        // POST: PdnCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PdnId,PdnName,PdnStatus,CreatedDate")] PdnCategory pdncategory)
        {
            if (id != pdncategory.PdnId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    pdncategory.CreatedDate = DateTime.Now;
                    _context.Update(pdncategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PdnCategoryExists(pdncategory.PdnId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pdncategory);
        }

        // GET: PdnCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdncategory = await _context.Categories
                .FirstOrDefaultAsync(m => m.PdnId == id);
            if (pdncategory == null)
            {
                return NotFound();
            }

            return View(pdncategory);
        }

        // POST: PdnCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pdncategory = await _context.Categories.FindAsync(id);
            if (pdncategory != null)
            {
                _context.Categories.Remove(pdncategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PdnCategoryExists(int id)
        {
            return _context.Categories.Any(e => e.PdnId == id);
        }
    }
}