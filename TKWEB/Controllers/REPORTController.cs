﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class REPORTController : Controller
    {
        private readonly TKWEBContext _context;

        public REPORTController(TKWEBContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,Normal,102400")]
        public async Task<IActionResult> Index(string STARTDATES,string ENDDATES)
        {
            string query=null;
           

            var IdentityNAME = User.Identity.Name;
            var IdentityNAMEARRAY = IdentityNAME.ToString().Split("@");
            var SUERNAME = IdentityNAMEARRAY[0].ToString();

            var user = new SqlParameter("user", SUERNAME);
            var sdats = new SqlParameter("sdats", STARTDATES);
            var edats = new SqlParameter("edats", ENDDATES);


            if (!String.IsNullOrEmpty(STARTDATES)&& !String.IsNullOrEmpty(ENDDATES))
            {
                query = "SELECT [ID],[WROKDATES],[LOGINID],[WORKID],[HRS] FROM [TKWEB].[dbo].[HRIDWORKHRS]  WHERE [LOGINID]=@user AND CONVERT(NVARCHAR,[WROKDATES],112)>=@sdats AND CONVERT(NVARCHAR,[WROKDATES],112)<=@edats  ORDER BY [WROKDATES] DESC ";
                var result = await _context.Hridworkhrs.FromSqlRaw(query, user, sdats, edats).ToListAsync();

                return View(result);

            }
            else 
            {
                query = "SELECT TOP 1 [ID],[WROKDATES],[LOGINID],[WORKID],[HRS] FROM [TKWEB].[dbo].[HRIDWORKHRS]  WHERE [LOGINID]=@user AND CONVERT(NVARCHAR,[WROKDATES],112) LIKE SUBSTRING(CONVERT(NVARCHAR,GETDATE(),112),1,6)+'%'  ORDER BY [WROKDATES] DESC ";
                var result = await _context.Hridworkhrs.FromSqlRaw(query, user).ToListAsync();

                return View(result);
            }
           
            

            //return View(await _context.Hridworkhrs.Where(s => s.Loginid == SUERNAME.ToString()).ToListAsync());
            //return View(await _context.Hridworkhrs.ToListAsync());
        }

     

    }
}