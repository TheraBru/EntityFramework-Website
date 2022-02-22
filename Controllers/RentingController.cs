#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using moment32.Data;
using moment32.Models;

namespace moment32.Controllers
{
    public class RentingController : Controller
    {
        private readonly RecordContext _context;

        public RentingController(RecordContext context)
        {
            _context = context;
        }

        // GET: Renting
        public async Task<IActionResult> Index()
        {
            var recordContext = _context.Renting.Include(r => r.Record).Include(r => r.User);
            return View(await recordContext.ToListAsync());
        }

        // GET: Renting/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renting = await _context.Renting
                .Include(r => r.Record)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RentingId == id);
            if (renting == null)
            {
                return NotFound();
            }

            return View(renting);
        }

        // GET: Renting/Create
        public IActionResult Create()
        {
            ViewData["RecordId"] = new SelectList(_context.Record, "RecordId", "RecordName");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName");
            return View();
        }

        // POST: Renting/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentingId,Rented,RecordId,UserId")] Renting renting)
        {
            if (ModelState.IsValid){
                var newRenting = await _context.Renting
                .Include(r => r.Record)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RecordId == renting.RecordId);

                if (newRenting != null){
                    ViewData["ErrorMsg"] = "Tyvärr, denna skiva är redan utlånad";
                    ViewData["RecordId"] = new SelectList(_context.Record, "RecordId", "RecordName");
                    ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName");
                    return View();
                }else{
                    _context.Add(renting);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["RecordId"] = new SelectList(_context.Record, "RecordId", "RecordName", renting.RecordId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName", renting.UserId);
            return View(renting);
        }

        // GET: Renting/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renting = await _context.Renting.FindAsync(id);
            if (renting == null)
            {
                return NotFound();
            }
            ViewData["RecordId"] = new SelectList(_context.Record, "RecordId", "RecordName", renting.RecordId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName", renting.UserId);
            return View(renting);
        }

        // POST: Renting/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentingId,Rented,RecordId,UserId")] Renting renting)
        {
            if (id != renting.RentingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentingExists(renting.RentingId))
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
            ViewData["RecordId"] = new SelectList(_context.Record, "RecordId", "RecordName", renting.RecordId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName", renting.UserId);
            return View(renting);
        }

        // GET: Renting/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renting = await _context.Renting
                .Include(r => r.Record)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RentingId == id);
            if (renting == null)
            {
                return NotFound();
            }

            return View(renting);
        }

        // POST: Renting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var renting = await _context.Renting.FindAsync(id);
            _context.Renting.Remove(renting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentingExists(int id)
        {
            return _context.Renting.Any(e => e.RentingId == id);
        }
    }
}
