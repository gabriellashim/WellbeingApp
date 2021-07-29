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

        public async Task<IActionResult> StudentEditAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.WebAppUsers.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator, Leader, Senior Leader")]
        //public async Task<IActionResult> LeaderHome([Bind("UserID,RoleID")] Microsoft.AspNetCore.Identity.IdentityRole assignedRole)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        _context.Add(assignedRole);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(assignedRole);
        //}

        // POST: LeadersAssigneds/ViewAllStudent/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StudentEdit(string id, [Bind(",LeaderAssignedID")] WebAppUser leadersAssigned)
        {

            if (id != leadersAssigned.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leadersAssigned);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaderAssignedExists(leadersAssigned.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(StudentEdit));
            }
            return View(leadersAssigned);
        }

        private bool LeaderAssignedExists(string id)
        {
            return _context.WebAppUsers.Any(e => e.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignLeader(string id, [Bind("LeaderAssignedID")] WebAppUser leadersAssigned)
        {

            if (id != leadersAssigned.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leadersAssigned);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaderAssignedExists(leadersAssigned.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(StudentEdit));
            }
            return View(leadersAssigned);
        }

        //public ActionResult AssignLeader(bool isActive = false)
        //{
        //    var list = _userManager.Users
        //        .OrderBy(lname => lname.LastName)
        //        .OrderBy(fname => fname.FirstName)
        //        .Select(users => users);

        //    if (isActive)
        //    {
        //        list = list.Where(user => user.IsActive == isActive);
        //    }
        //    return View(list);
        //}

        public async Task<IActionResult> AssignLeader()
        {
            return View(await _context.WebAppUsers.ToListAsync());
        }


    }
}
