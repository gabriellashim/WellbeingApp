using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quokka_App.Data;
using Quokka_App.Model;

namespace Quokka_App.Controllers
{
    public class LeadersAssignedsController : Controller
    {
        private readonly LeadersAssignedContext _context;

        public LeadersAssignedsController(LeadersAssignedContext context)
        {
            _context = context;
        }

        // GET: LeadersAssigneds
        public async Task<IActionResult> Index()
        {
            return View(await _context.LeadersAssigned.ToListAsync());
        }

        // GET: ViewAllStudent
        public async Task<IActionResult> ViewAllStudent()
        {
            return View(await _context.AspNetUsers.ToListAsync());
        }

        // GET: ViewWeekly
        public async Task<IActionResult> ViewWeekly()
        {
            return View(await _context.Emotion.ToListAsync());
        }

        // GET: ViewNotification
        public async Task<IActionResult> ViewNotification()
        {
            return View(await _context.Emotion.ToListAsync());
        }

        // GET: Create
        public async Task<IActionResult> Create()
        {
            return View(await _context.Emotion.ToListAsync());
        }

        // GET: ViewMonthly
        public async Task<IActionResult> ViewMonthly()
        {
            return View(await _context.Emotion.ToListAsync());
        }

        // GET: LeadersAssigneds/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadersAssigned = await _context.LeadersAssigned
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leadersAssigned == null)
            {
                return NotFound();
            }

            return View(leadersAssigned);
        }

        // GET: LeadersAssigneds/Create
        //public IActionResult Create()
        //{
            //return View();
        //}

        // POST: LeadersAssigneds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,leaderID,studentID")] LeadersAssigned leadersAssigned)
        {
            if (ModelState.IsValid)
            {

                _context.Add(leadersAssigned);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leadersAssigned);
        }


        // GET: LeadersAssigneds/ViewAllStudent/Edit
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadersAssigned = await _context.AspNetUsers.FindAsync(id);
            if (leadersAssigned == null)
            {
                return NotFound();
            }
            return View(leadersAssigned);
        }

        // POST: LeadersAssigneds/ViewAllStudent/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,UserName,AccountType,LeaderAssigned")] AspNewUsers leadersAssigned)
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
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadersAssigned = await _context.AspNetUsers
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
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var leadersAssigned = await _context.AspNetUsers.FindAsync(id);
            _context.AspNetUsers.Remove(leadersAssigned);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Create));
        }

        private bool LeadersAssignedExists(string id)
        {
            return _context.LeadersAssigned.Any(e => e.Id == id);
        }

    }
}
