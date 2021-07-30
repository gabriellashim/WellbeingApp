using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quokka_App.Data;
using Quokka_App.Model;

namespace Quokka_App.Controllers
{
    //[Authorize(Roles = "Administrator, Student")]
    public class Reports : Controller
    {
        private readonly WebAppContext _context;
        private readonly UserManager<WebAppUser> _userManager;

        public Reports(WebAppContext context, UserManager<WebAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Emotions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emotion = await _context.StudentReportDb
                .FirstOrDefaultAsync(m => m.ID == id);
            if (emotion == null)
            {
                return NotFound();
            }

            return View(emotion);
        }

        // GET: Emotions
        //[Authorize(Roles = "Student")]
        public IActionResult Confirmation()
        {
            ViewBag.FirstName = _userManager.GetUserAsync(User).Result.FirstName;
            return View();
        }

        // GET: Emotions/LeaderHome (Student Main Page)
        //[Authorize(Roles = "Student")]
        public IActionResult StudentHome()
        {
            return View();
        }

        // GET: (Student Main Page)
        //[Authorize(Roles = "Student")]
        //public IActionResult StudentHome(string id)
        //{
        //    var report = _context.StudentReportDb
        //        .Include(c => c.ID)
        //        .SingleOrDefault(x => x.UserID == id);

        //    return View(report);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Student")]
        public async Task<IActionResult> StudentHome([Bind("ID,StudentID,Feeling,ReportDate,AppointmentDate,StudentComment")] StudentReports emotion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emotion);
                await _context.SaveChangesAsync();
                return RedirectToAction("StudentCommentView", new {emotion.ID});
            }
            return View(emotion);
        }

        // GET:
        //[Authorize(Roles = "Student")]
        public async Task<IActionResult> StudentCommentView(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emotion = await _context.StudentReportDb.FindAsync(id);
            if (emotion == null)
            {
                return NotFound();
            }
            return View(emotion);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Student")]
        public async Task<IActionResult> StudentCommentView(int id, [Bind("ID,Feeling,ReportDate,AppointmentDate,StudentComment,ReporterID,EmotionID")] StudentReports emotion)
        {
            if (id != emotion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emotion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmotionExists(emotion.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Confirmation));
            }
            return View(emotion);
        }

        // GET: 
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emotion = await _context.StudentReportDb
                .FirstOrDefaultAsync(m => m.ID == id);
            if (emotion == null)
            {
                return NotFound();
            }

            return View(emotion);
        }

        // POST: Emotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emotion = await _context.StudentReportDb.FindAsync(id);
            _context.StudentReportDb.Remove(emotion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(StudentHome));
        }

        private bool EmotionExists(int id)
        {
            return _context.StudentReportDb.Any(e => e.ID == id);
        }
    }
}
