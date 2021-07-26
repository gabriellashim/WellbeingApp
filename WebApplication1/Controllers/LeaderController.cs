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
using Quokka_App.Model;

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

        // GET: ViewWeekly
        [Authorize(Roles = "Administrator, Leader, Senior Leader")]
        public async Task<IActionResult> ViewWeekly()
        {
            return View(await _context.StudentReportDb.ToListAsync());
        }

        // GET: ViewNotification
        //[Authorize(Roles = "Administrator, Leader, Senior Leader")]
        public async Task<IActionResult> ViewNotification()
        {
            return View(await _context.StudentReportDb.ToListAsync());
        }

        // GET: LeaderHome
        //[Authorize(Roles = "Administrator, Leader, Senior Leader")]
        public async Task<IActionResult> LeaderHome()
        {
            return View(await _context.StudentReportDb.ToListAsync());
        }

        // GET: ViewMonthly
        // [Authorize(Roles = "Administrator, Leader, Senior Leader")]
        public IActionResult ViewMonthly(bool isActive = true)
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

        // POST: LeadersAssigneds/LeaderHome
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator, Leader, Senior Leader")]
        public async Task<IActionResult> LeaderHome([Bind("UserID,RoleID")] IdentityRole assignedRole)
        {
            if (ModelState.IsValid)
            {

                _context.Add(assignedRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assignedRole);
        }

        // GET: LeadersAssigneds/ViewAllStudent/Edit
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadersAssigned = await _context.WebAppUsers.FindAsync(id);
            if (leadersAssigned == null)
            {
                return NotFound();
            }
            return View(leadersAssigned);
        }

        // POST: LeadersAssigneds/ViewAllStudent/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,UserName,AccountType,LeaderAssigned")] WebAppUser leadersAssigned)
        {

            if (id != leadersAssigned.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(leadersAssigned);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ViewAllStudent));
            }
            return View(leadersAssigned);
        }

        // GET: LeadersAssigneds/ViewAllStudent/Delete
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadersAssigned = await _context.WebAppUsers
                .FirstOrDefaultAsync(m => m.Id == id);

            if (leadersAssigned == null)
            {
                return NotFound();
            }

            return View(leadersAssigned);
        }

        // POST: LeadersAssigneds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var leadersAssigned = await _context.WebAppUsers.FindAsync(id);
            _context.WebAppUsers.Remove(leadersAssigned);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(LeaderHome));
        }

        //private bool leadersassignedexists(string id)
        //{
        //    return _context.leadersassigned.any(e => e.id == id);
        //}

        public async Task<IActionResult> AssignLeader([Bind("CheckedBy,ReportChecked,AssignedDate,CompleteDate")] LeaderAssignedReport leaderAssigned)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaderAssigned);
                await _context.SaveChangesAsync();
                return RedirectToAction("StudentCommentView", new { leaderAssigned });
            }
            return View(leaderAssigned);
        }

        public void AssignLeaderToStudent(object sender, EventArgs e)
        {
            
        }
    }
}
