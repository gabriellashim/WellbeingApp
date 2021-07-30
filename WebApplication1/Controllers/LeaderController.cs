using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Quokka_App.Data;
using Quokka_App.Migrations;
using Quokka_App.Model;
using Quokka_App.ViewModel;

namespace Quokka_App.Controllers
{

    public class LeaderController : Controller
    {
        private readonly WebAppContext _context;
        private readonly UserManager<WebAppUser> _userManager;
        private readonly ILogger<LeaderController> _logger;

        public LeaderController(WebAppContext context, UserManager<WebAppUser> userManager, ILogger<LeaderController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public ActionResult ViewAllStudent(bool isActive = true)
        {
            var list = _userManager.Users
                .OrderBy(lname => lname.LastName)
                .OrderBy(fname => fname.FirstName)
                .Select(users => users);

            if (isActive)
            {
                list = list.Where(user => user.IsActive == isActive);
            }
            return View(list);
        }

        // GET: ViewNotification
        //[Authorize(Roles = "Administrator, Leader, Senior Leader")]
        public async Task<IActionResult> Notification()
        {
            //var userRoles = await _userManager.GetUsersInRoleAsync("Student");
            var userReports = await _context.StudentReportDb.ToListAsync();
            return View(userReports);
        }

        // GET: LeaderHome
        //[Authorize(Roles = "Administrator, Leader, Senior Leader")]
        public async Task<IActionResult> LeaderHome()
        {
            return View(await _context.StudentReportDb.ToListAsync());
        }

        // GET: ViewMonthly
        // [Authorize(Roles = "Administrator, Leader, Senior Leader")]
        public IActionResult ViewMonthly()
        {
            var report = _context.StudentReportDb.OrderBy(a => a.EmotionID).Select(x => x);

            //if (isComplete)
            //{
            //    report = report.Where(user => user.IsComplete == isComplete);
            //}

            return View(report);
        }

        private bool LeaderAssignedExists(string id)
        {
            return _context.WebAppUsers.Any(e => e.Id == id);
        }

        // GET: EmergencyContacts/Edit/5
        public async Task<IActionResult> StudentEdit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UsersReportsViewModel viewmodel = new UsersReportsViewModel
            {
                ApplicationUser = await _context.WebAppUsers.FindAsync(id),
                
            };

            var user = await _context.WebAppUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> StudentEdit([Bind("ID,id,AssignedDate,CompleteDate")] LeaderAssignedReport report)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(report);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(report);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StudentEdit(
            string id, [
            Bind(
            "Id, " +
            "FirstName, " +
            "LastName, " +
            "IsActive, " +
            "AccountCreated, " +
            "LeaderAssignedID"
            )] WebAppUser leader)
        {
            if (id != leader.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.WebAppUsers.Update(leader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaderAssignedExists(leader.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(AssignLeader));
            }
            return View(leader);
        }

        //public async Task<IActionResult> AssignLeader(bool isComplete = true)
        //{

        //    var list = _userManager.Users
        //        .OrderBy(lname => lname.LastName)
        //        .OrderBy(fname => fname.FirstName)
        //        .Select(users => users);

        //    if (isComplete)
        //    {
        //        list = list.Where(user => user.IsActive == isComplete);
        //    }
        //    return View(list);
        //}

        //bool isComplete = true)

        public async Task<IActionResult> AssignLeader()
        {
            //UsersReportsViewModel viewmodel = new UsersReportsViewModel();
            return View(await _context.WebAppUsers.ToListAsync());
        }

    }
}
