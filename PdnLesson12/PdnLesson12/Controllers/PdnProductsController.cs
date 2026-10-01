using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PdnLesson12.Models;
using PdnLesson12.PdnEntities;

namespace PdnLesson12.Controllers
{
    public class PdnProductsController : Controller
    {
        private readonly PdnAppDbContext _context;

        public PdnProductsController(PdnAppDbContext context)
        {
            _context = context;
        }

        // GET: PdnProducts
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Include(p => p.PdnCategory).ToListAsync();
            return View(products);
        }

        // GET: PdnProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdnproduct = await _context.Products
                .Include(p => p.PdnCategory)
                .FirstOrDefaultAsync(m => m.PdnId == id);

            if (pdnproduct == null)
            {
                return NotFound();
            }

            return View(pdnproduct);
        }

        // GET: PdnProducts/Create
        public IActionResult Create()
        {
            ViewData["PdnCategoryId"] = new SelectList(_context.Categories, "PdnId", "PdnName");
            return View();
        }

        // POST: PdnProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PdnId,PdnName,PdnPrice,PdnSalePrice,PdnStatus,PdnDescription,PdnCategoryId")] PdnProduct pdnproduct)
        {
            // Bỏ qua kiểm tra Navigation Property và CreatedDate nếu không bắt buộc nhập từ View
            ModelState.Remove("PdnCategory");
            ModelState.Remove("PdnImage");
            ModelState.Remove("CreatedDate");

            if (ModelState.IsValid)
            {
                // Upload file ảnh vào thư mục wwwroot/Product theo hướng dẫn
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var fileName = file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Product", fileName);

                    // Tạo thư mục wwwroot/Product nếu chưa tồn tại
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Product");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        pdnproduct.PdnImage = fileName; // Gán tên ảnh cho thuộc tính PdnImage
                    }
                }

                pdnproduct.CreatedDate = DateTime.Now;
                _context.Add(pdnproduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["PdnCategoryId"] = new SelectList(_context.Categories, "PdnId", "PdnName", pdnproduct.PdnCategoryId);
            return View(pdnproduct);
        }

        // GET: PdnProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdnproduct = await _context.Products.FindAsync(id);
            if (pdnproduct == null)
            {
                return NotFound();
            }

            ViewData["PdnCategoryId"] = new SelectList(_context.Categories, "PdnId", "PdnName", pdnproduct.PdnCategoryId);
            return View(pdnproduct);
        }

        // POST: PdnProducts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PdnId,PdnName,PdnImage,PdnPrice,PdnSalePrice,PdnStatus,PdnDescription,PdnCategoryId")] PdnProduct pdnproduct)
        {
            if (id != pdnproduct.PdnId)
            {
                return NotFound();
            }

            ModelState.Remove("PdnCategory");
            ModelState.Remove("PdnImage");
            ModelState.Remove("CreatedDate");

            if (ModelState.IsValid)
            {
                try
                {
                    // Xử lý upload ảnh mới (nếu người dùng chọn ảnh mới)
                    var files = HttpContext.Request.Form.Files;
                    if (files.Count > 0 && files[0].Length > 0)
                    {
                        var file = files[0];
                        var fileName = file.FileName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Product", fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                            pdnproduct.PdnImage = fileName;
                        }
                    }

                    pdnproduct.CreatedDate = DateTime.Now;
                    _context.Update(pdnproduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PdnProductExists(pdnproduct.PdnId))
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

            ViewData["PdnCategoryId"] = new SelectList(_context.Categories, "PdnId", "PdnName", pdnproduct.PdnCategoryId);
            return View(pdnproduct);
        }

        // GET: PdnProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdnproduct = await _context.Products
                .Include(p => p.PdnCategory)
                .FirstOrDefaultAsync(m => m.PdnId == id);

            if (pdnproduct == null)
            {
                return NotFound();
            }

            return View(pdnproduct);
        }

        // POST: PdnProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pdnproduct = await _context.Products.FindAsync(id);
            if (pdnproduct != null)
            {
                _context.Products.Remove(pdnproduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PdnProductExists(int id)
        {
            return _context.Products.Any(e => e.PdnId == id);
        }
    }
}