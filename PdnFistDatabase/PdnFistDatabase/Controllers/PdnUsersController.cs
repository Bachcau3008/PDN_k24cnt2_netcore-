using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdnFirstDatabase.Models;

namespace PdnFistDatabase.Controllers
{
    public class PdnUsersController : Controller
    {
        private readonly PdnLesson10EfdbContext _context;

        public PdnUsersController(PdnLesson10EfdbContext context)
        {
            _context = context;
        }

        // GET: PdnUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.PdnUsers.ToListAsync());
        }

        // GET: PdnUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdnUser = await _context.PdnUsers
                .FirstOrDefaultAsync(m => m.PdnId == id);
            if (pdnUser == null)
            {
                return NotFound();
            }

            return View(pdnUser);
        }

        // GET: PdnUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PdnUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PdnId,PdnUsername,PdnPassword,PdnFullName,PdnEmail,PdnPhone")] PdnUser pdnUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pdnUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pdnUser);
        }

        // GET: PdnUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdnUser = await _context.PdnUsers.FindAsync(id);
            if (pdnUser == null)
            {
                return NotFound();
            }
            return View(pdnUser);
        }

        // POST: PdnUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PdnId,PdnUsername,PdnPassword,PdnFullName,PdnEmail,PdnPhone")] PdnUser pdnUser)
        {
            if (id != pdnUser.PdnId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pdnUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PdnUserExists(pdnUser.PdnId))
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
            return View(pdnUser);
        }

        // GET: PdnUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdnUser = await _context.PdnUsers
                .FirstOrDefaultAsync(m => m.PdnId == id);
            if (pdnUser == null)
            {
                return NotFound();
            }

            return View(pdnUser);
        }

        // POST: PdnUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pdnUser = await _context.PdnUsers.FindAsync(id);
            if (pdnUser != null)
            {
                _context.PdnUsers.Remove(pdnUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PdnUserExists(int id)
        {
            return _context.PdnUsers.Any(e => e.PdnId == id);
        }
    }
}
