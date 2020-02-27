using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TKWEB.Models;
using ActionNameAttribute = Microsoft.AspNetCore.Mvc.ActionNameAttribute;
using BindAttribute = Microsoft.AspNetCore.Mvc.BindAttribute;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;
using ValidateAntiForgeryTokenAttribute = Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute;

namespace TKWEB.Controllers
{
    public class EventViewModelsController : Controller
    {
        private readonly TKWEBContext _context;

        public EventViewModelsController(TKWEBContext context)
        {
            _context = context;
        }

        // GET: EventViewModels
        public async Task<IActionResult> Index()
        {
            return View();
            //return View(await _context.EventViewModel.ToListAsync());
        }

        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var viewModel = new EventViewModel();
            var events = new List<EventViewModel>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-11);

            //for (var i = 1; i <= 5; i++)
            //{
            //    events.Add(new EventViewModel()
            //    {
            //        id = i,
            //        title = "Event " + i,
            //        start = start.ToString(),
            //        end = end.ToString(),
            //        allDay = false
            //    });

            //    start = start.AddDays(7);
            //    end = end.AddDays(7);
            //}

            //allDay要設定ture，不然event會多出 12a
            events.Add(new EventViewModel()
            {
                id = 1,
                title = "Event " + 1,
                start = DateTime.Today.ToString("yyyy-MM-dd"),
                allDay=true
            }) ;

            events.Add(new EventViewModel()
            {
                id = 2,
                title = "Event " + 2,
                start = "2020-02-20",
                allDay = true
            });

            return Json(events);
        }

        // GET: EventViewModels/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = await _context.EventViewModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (eventViewModel == null)
            {
                return NotFound();
            }

            return View(eventViewModel);
        }

        // GET: EventViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,start,end,allDay")] EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventViewModel);
        }

        // GET: EventViewModels/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = await _context.EventViewModel.FindAsync(id);
            if (eventViewModel == null)
            {
                return NotFound();
            }
            return View(eventViewModel);
        }

        // POST: EventViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,title,start,end,allDay")] EventViewModel eventViewModel)
        {
            if (id != eventViewModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventViewModelExists(eventViewModel.id))
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
            return View(eventViewModel);
        }

        // GET: EventViewModels/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = await _context.EventViewModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (eventViewModel == null)
            {
                return NotFound();
            }

            return View(eventViewModel);
        }

        // POST: EventViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var eventViewModel = await _context.EventViewModel.FindAsync(id);
            _context.EventViewModel.Remove(eventViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventViewModelExists(long id)
        {
            return _context.EventViewModel.Any(e => e.id == id);
        }
    }
}
