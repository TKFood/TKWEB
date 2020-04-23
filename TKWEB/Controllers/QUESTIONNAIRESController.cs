using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TKWEB.Models;

namespace TKWEB.Controllers
{
    public class QUESTIONNAIRESController : Controller
    {
        private readonly TKWEBContext _context;

        public QUESTIONNAIRESController(TKWEBContext context)
        {
            _context = context;
        }

        // GET: QUESTIONNAIRES
        public async Task<IActionResult> Index()
        {
            return View(await _context.QUESTIONNAIRES.ToListAsync());
        }

        // GET: QUESTIONNAIRES/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qUESTIONNAIRES = await _context.QUESTIONNAIRES
                .FirstOrDefaultAsync(m => m.ID == id);
            if (qUESTIONNAIRES == null)
            {
                return NotFound();
            }

            return View(qUESTIONNAIRES);
        }

        // GET: QUESTIONNAIRES/Create
        public IActionResult Create()
        {
            List<QUESTIONDEP> QUESTIONDEPLIST = new List<QUESTIONDEP>();

            QUESTIONDEPLIST = (from QUESTIONDEP in _context.QUESTIONDEP select QUESTIONDEP).ToList();          

            ViewBag.QUESTIONDEPLIST = QUESTIONDEPLIST.Select(c => new SelectListItem { Value = c.DEPID, Text = c.DEPNAME }).ToList();


            return View();
        }

        // POST: QUESTIONNAIRES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DATES,NO,NAME,DEP,QUESTION1,QUESTION2,QUESTION3,QUESTION4,QUESTION5,QUESTION6,QUESTION7,QUESTION8,QUESTION9,QUESTION10,QUESTION11")] QUESTIONNAIRES qUESTIONNAIRES)
        {            
            if (ModelState.IsValid)
            {
                //qUESTIONNAIRES.QUESTION1 = "ABCD";


                qUESTIONNAIRES.ID = Guid.NewGuid();
                _context.Add(qUESTIONNAIRES);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qUESTIONNAIRES);
        }

        // GET: QUESTIONNAIRES/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qUESTIONNAIRES = await _context.QUESTIONNAIRES.FindAsync(id);
            if (qUESTIONNAIRES == null)
            {
                return NotFound();
            }
            return View(qUESTIONNAIRES);
        }

        // POST: QUESTIONNAIRES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,DATES,NO,NAME,DEP,QUESTION1,QUESTION2,QUESTION3,QUESTION4,QUESTION5,QUESTION6,QUESTION7,QUESTION8,QUESTION9,QUESTION10,QUESTION11")] QUESTIONNAIRES qUESTIONNAIRES)
        {
            if (id != qUESTIONNAIRES.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qUESTIONNAIRES);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QUESTIONNAIRESExists(qUESTIONNAIRES.ID))
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
            return View(qUESTIONNAIRES);
        }

        // GET: QUESTIONNAIRES/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qUESTIONNAIRES = await _context.QUESTIONNAIRES
                .FirstOrDefaultAsync(m => m.ID == id);
            if (qUESTIONNAIRES == null)
            {
                return NotFound();
            }

            return View(qUESTIONNAIRES);
        }

        // POST: QUESTIONNAIRES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var qUESTIONNAIRES = await _context.QUESTIONNAIRES.FindAsync(id);
            _context.QUESTIONNAIRES.Remove(qUESTIONNAIRES);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QUESTIONNAIRESExists(Guid id)
        {
            return _context.QUESTIONNAIRES.Any(e => e.ID == id);
        }
    }
}
