using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
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

        [Authorize(Roles = "Admin,Normal,102400,102500")]
        // GET: Hridworkhrs
        public async Task<IActionResult> Index(string STARTDATES, string ENDDATES)
        {
            string query = null;


            var IdentityNAME = User.Identity.Name;
            var IdentityNAMEARRAY = IdentityNAME.ToString().Split("@");
            var SUERNAME = IdentityNAMEARRAY[0].ToString();

            var user = new SqlParameter("user", SUERNAME);
            var sdats = new SqlParameter("sdats", STARTDATES);
            var edats = new SqlParameter("edats", ENDDATES);


            if (!String.IsNullOrEmpty(STARTDATES) && !String.IsNullOrEmpty(ENDDATES))
            {
                query = "SELECT [ID],[WROKDATES],[LOGINID],[WORKID],[HRS] FROM [TKWEB].[dbo].[HRIDWORKHRS]  WHERE [LOGINID]=@user AND CONVERT(NVARCHAR,[WROKDATES],112)>=@sdats AND CONVERT(NVARCHAR,[WROKDATES],112)<=@edats  ORDER BY [WROKDATES] DESC ";
                var result = await _context.Hridworkhrs.FromSqlRaw(query, user, sdats, edats).ToListAsync();

                return View(result);

            }
            else
            {
                query = "SELECT TOP 5 [ID],[WROKDATES],[LOGINID],[WORKID],[HRS] FROM [TKWEB].[dbo].[HRIDWORKHRS]  WHERE [LOGINID]=@user AND CONVERT(NVARCHAR,[WROKDATES],112) LIKE SUBSTRING(CONVERT(NVARCHAR,GETDATE(),112),1,6)+'%'  ORDER BY [WROKDATES] DESC ";
                var result = await _context.Hridworkhrs.FromSqlRaw(query, user).ToListAsync();

                return View(result);
            }

            //return View(await _context.Hridworkhrs.Where(s => s.Loginid == SUERNAME.ToString()).ToListAsync());
            //return View(await _context.Hridworkhrs.ToListAsync());
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
            var IdentityNAME = User.Identity.Name;
            var IdentityNAMEARRAY = IdentityNAME.ToString().Split("@");
            var SUERNAME = IdentityNAMEARRAY[0].ToString();

            ViewBag.Name = SUERNAME.ToString();

            var query = (from Hrworks in _context.Hrwork
                         join Hrrolework in _context.Hrrolework on Hrworks.Workid equals Hrrolework.Workid
                         join aspNetRoles in _context.AspNetRoles on Hrrolework.Role equals aspNetRoles.Name
                         join aspNetUserRoles in _context.AspNetUserRoles on aspNetRoles.Id equals aspNetUserRoles.RoleId
                         join aspNetUsers in _context.AspNetUsers on aspNetUserRoles.UserId equals aspNetUsers.Id
                         where aspNetUsers.UserName == IdentityNAME.ToString()
                         select new
                         {
                             Workid = Hrworks.Workid,
                             Workname = Hrworks.Workname,
                         }).ToList();

            ViewBag.Hrworks = query.Select(c => new SelectListItem { Value = c.Workname.ToString(), Text = c.Workname }).ToList();


            //ViewBag.Locations = _context.Hrwork.Select(c => new SelectListItem { Value = c.Workid.ToString(), Text = c.Workname }).ToList();

            ////Creating generic list
            //List<SelectListItem> ObjList = new List<SelectListItem>()
            //{
            //    new SelectListItem { Text = "Latur", Value = "1" },
            //    new SelectListItem { Text = "Pune", Value = "2" },
            //    new SelectListItem { Text = "Mumbai", Value = "3" },
            //    new SelectListItem { Text = "Delhi", Value = "4" },

            //};
            ////Assigning generic list to ViewBag
            //ViewBag.Locations = ObjList;

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
