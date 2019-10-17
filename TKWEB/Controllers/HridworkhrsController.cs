using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TKWEB.Models;

namespace TKWEB.Controllers
{
    public class HridworkhrsController : Controller
    {
        private readonly TKWEBContext _context;

        public HridworkhrsController(TKWEBContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,Normal")]
        // GET: Hridworkhrs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hridworkhrs.ToListAsync());
        }

        // GET: Hridworkhrs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hridworkhrs = await _context.Hridworkhrs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hridworkhrs == null)
            {
                return NotFound();
            }

            return View(hridworkhrs);
        }

        // GET: Hridworkhrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hridworkhrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Wrokdates,Loginid,Workid,Hrs")] Hridworkhrs hridworkhrs)
        {
            if (ModelState.IsValid)
            {
                hridworkhrs.Id = Guid.NewGuid();
                _context.Add(hridworkhrs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hridworkhrs);
        }

        // GET: Hridworkhrs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hridworkhrs = await _context.Hridworkhrs.FindAsync(id);
            if (hridworkhrs == null)
            {
                return NotFound();
            }
            return View(hridworkhrs);
        }

        // POST: Hridworkhrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Wrokdates,Loginid,Workid,Hrs")] Hridworkhrs hridworkhrs)
        {
            if (id != hridworkhrs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hridworkhrs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HridworkhrsExists(hridworkhrs.Id))
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
            return View(hridworkhrs);
        }

        // GET: Hridworkhrs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hridworkhrs = await _context.Hridworkhrs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hridworkhrs == null)
            {
                return NotFound();
            }

            return View(hridworkhrs);
        }

        // POST: Hridworkhrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var hridworkhrs = await _context.Hridworkhrs.FindAsync(id);
            _context.Hridworkhrs.Remove(hridworkhrs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HridworkhrsExists(Guid id)
        {
            return _context.Hridworkhrs.Any(e => e.Id == id);
        }
    }
}
