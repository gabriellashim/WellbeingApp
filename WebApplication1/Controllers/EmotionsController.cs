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
    public class EmotionsController : Controller
    {
        private readonly LeadersAssignedContext _context;

        public EmotionsController(LeadersAssignedContext context)
        {
            _context = context;
        }


        // GET: Emotions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emotion = await _context.Emotion
                .FirstOrDefaultAsync(m => m.ID == id);
            if (emotion == null)
            {
                return NotFound();
            }

            return View(emotion);
        }

        // GET: Emotions
        public IActionResult Confirmation()
        {
            return View();
        }

        // GET: Emotions/Create (Student Main Page)
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emotions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,studentId,feeling,date,whenToSee,description")] Emotion emotion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emotion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", new {emotion.ID});
            }
            return View(emotion);
        }

        // GET: Emotions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emotion = await _context.Emotion.FindAsync(id);
            if (emotion == null)
            {
                return NotFound();
            }
            return View(emotion);
        }

        // POST: Emotions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,studentId,feeling,date,whenToSee,description")] Emotion emotion)
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

        // GET: Emotions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emotion = await _context.Emotion
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
            var emotion = await _context.Emotion.FindAsync(id);
            _context.Emotion.Remove(emotion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Create));
        }

        private bool EmotionExists(int id)
        {
            return _context.Emotion.Any(e => e.ID == id);
        }
    }
}
