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

        // GET: LeadersAssigneds/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public IActionResult Create()
        {
            return View();
        }

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

        // GET: LeadersAssigneds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadersAssigned = await _context.LeadersAssigned.FindAsync(id);
            if (leadersAssigned == null)
            {
                return NotFound();
            }
            return View(leadersAssigned);
        }

        // POST: LeadersAssigneds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,leaderID,studentID")] LeadersAssigned leadersAssigned)
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
                    if (!LeadersAssignedExists(leadersAssigned.Id))
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
            return View(leadersAssigned);
        }

        // GET: LeadersAssigneds/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: LeadersAssigneds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leadersAssigned = await _context.LeadersAssigned.FindAsync(id);
            _context.LeadersAssigned.Remove(leadersAssigned);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeadersAssignedExists(int id)
        {
            return _context.LeadersAssigned.Any(e => e.Id == id);
        }
    }
}
