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
            //ViewBag讀取DB的方法，DB、TABLE跟MODEL要先建立好才可以用
            //List<QUESTIONDEP> QUESTIONDEPLIST = new List<QUESTIONDEP>();
            //QUESTIONDEPLIST = (from QUESTIONDEP in _context.QUESTIONDEP select QUESTIONDEP).ToList(); 
            //ViewBag.QUESTIONDEPLIST = QUESTIONDEPLIST.Select(c => new SelectListItem { Value = c.DEPID, Text = c.DEPNAME }).ToList();

            //ViewBag直接設定
            var DEPselectList = new List<SelectListItem>()
            {
                new SelectListItem {Text="總經理室(含經營分析中心、資訊管理中心、人資管理中心、新事業發展中心)", Value="總經理室(含經營分析中心、資訊管理中心、人資管理中心、新事業發展中心)" },
                new SelectListItem {Text="職安室", Value="職安室" },
                new SelectListItem {Text="管理部(含總務課)", Value="管理部(含總務課)" },
                new SelectListItem {Text="財務部(含成本課、會計課、財務課)", Value="財務部(含成本課、會計課、財務課)" },
                new SelectListItem {Text="資材部(含採購課)", Value="資材部(含採購課)" },
                new SelectListItem {Text="研發部(含產品開發課、研發課)", Value="研發部(含產品開發課、研發課)" },
                new SelectListItem {Text="品保部(含文管中心、品檢課、品保課)", Value="品保部(含文管中心、品檢課、品保課)" },
                new SelectListItem {Text="生產部(含倉儲課、工程課、製造課、手工課、內包課、外包課、生管課)", Value="生產部(含倉儲課、工程課、製造課、手工課、內包課、外包課、生管課)" },
                new SelectListItem {Text="事業拓展部(含大陸業務課、國外業務課、國內業務課)", Value="事業拓展部(含大陸業務課、國外業務課、國內業務課)" },
                new SelectListItem {Text="營銷部(含電子商務課、門市課、觀光課)", Value="營銷部(含電子商務課、門市課、觀光課)" },
                new SelectListItem {Text="行銷企劃部(含行銷企劃課、設計課)", Value="行銷企劃部(含行銷企劃課、設計課)" }
            };

            //預設選擇哪一筆
            //selectList.Where(q => q.Value == "value-2").First().Selected = true;
            ViewBag.DEPselectList = DEPselectList;

            // Build your models (example)
            var STATUSList = new List<SelectListItem>()
            {
             
                new SelectListItem {Text="發燒（額溫高於37.5度、耳溫高於38度、腋溫高於38度）", Value="發燒（額溫高於37.5度、耳溫高於38度、腋溫高於38度）" },
                new SelectListItem {Text="乾咳", Value="乾咳" },
                new SelectListItem {Text="嗅、味覺異常", Value="嗅、味覺異常" },
                new SelectListItem {Text="呼吸急促或困難", Value="呼吸急促或困難" },
                new SelectListItem {Text="不明原因腹瀉", Value="不明原因腹瀉" },
                new SelectListItem {Text="有呼吸道症狀（鼻塞、流鼻水、咳嗽）", Value="有呼吸道症狀（鼻塞、流鼻水、咳嗽）" },
                new SelectListItem {Text="否,以上皆無", Value="否,以上皆無" }

            };
            // Store your model in the ViewBag
            ViewBag.STATUSList = STATUSList;

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
