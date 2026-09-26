using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhamDinhNguye_exam.Models;

namespace PhamDinhNguye_exam.Controllers
{
    public class PdnMembersController : Controller
    {
        private readonly PdnEmployee241090057DbContext _context;

        public PdnMembersController(PdnEmployee241090057DbContext context)
        {
            _context = context;
        }

        // GET: PdnMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.PdnEmployees.ToListAsync());
        }

        // GET: PdnMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdnEmployee = await _context.PdnEmployees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pdnEmployee == null)
            {
                return NotFound();
            }

            return View(pdnEmployee);
        }

        // GET: PdnMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PdnMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PdnName,PdnGender,PdnBirthDay,PdnEmail,PdnPhone,PdnActive")] PdnEmployee pdnEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pdnEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pdnEmployee);
        }

        // GET: PdnMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdnEmployee = await _context.PdnEmployees.FindAsync(id);
            if (pdnEmployee == null)
            {
                return NotFound();
            }
            return View(pdnEmployee);
        }

        // POST: PdnMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PdnName,PdnGender,PdnBirthDay,PdnEmail,PdnPhone,PdnActive")] PdnEmployee pdnEmployee)
        {
            if (id != pdnEmployee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pdnEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PdnEmployeeExists(pdnEmployee.Id))
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
            return View(pdnEmployee);
        }

        // GET: PdnMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdnEmployee = await _context.PdnEmployees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pdnEmployee == null)
            {
                return NotFound();
            }

            return View(pdnEmployee);
        }

        // POST: PdnMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pdnEmployee = await _context.PdnEmployees.FindAsync(id);
            if (pdnEmployee != null)
            {
                _context.PdnEmployees.Remove(pdnEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PdnEmployeeExists(int id)
        {
            return _context.PdnEmployees.Any(e => e.Id == id);
        }
    }
}
