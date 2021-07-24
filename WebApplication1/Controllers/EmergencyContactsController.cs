﻿using System;
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
    public class EmergencyContactsController : Controller
    {
        private readonly WebAppContext _context;

        public EmergencyContactsController(WebAppContext context)
        {
            _context = context;
        }

        // GET: EmergencyContacts
        public async Task<IActionResult> EmergencyContactsView()
        {
            return View(await _context.EmergencyContacts.ToListAsync());
        }

        // GET: EmergencyContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmergencyContacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactID,ContactName,ContactPhone")] EmergencyContact emergencyContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emergencyContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emergencyContact);
        }

        // GET: EmergencyContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergencyContact = await _context.EmergencyContacts.FindAsync(id);
            if (emergencyContact == null)
            {
                return NotFound();
            }
            return View(emergencyContact);
        }

        // POST: EmergencyContacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactName,ContactPhone")] EmergencyContact emergencyContact)
        {
            if (ModelState.IsValid)
            {
                _context.Update(emergencyContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emergencyContact);
        }

        //private bool EmergencyContactExists(int id)
        //{
        //    return _context.EmergencyContacts.Any(e => e.ContactID == id);
        //}

        // GET: EmergencyContacts/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var emergencyContact = await _context.EmergencyContacts
        //        .FirstOrDefaultAsync(m => m.ContactID == id);
        //    if (emergencyContact == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(emergencyContact);
        //}

        //// GET: EmergencyContacts/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var emergencyContact = await _context.EmergencyContacts
        //        .FirstOrDefaultAsync(m => m.ContactID == id);
        //    if (emergencyContact == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(emergencyContact);
        //}



        //// POST: EmergencyContacts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var emergencyContact = await _context.EmergencyContacts.FindAsync(id);
        //    _context.EmergencyContacts.Remove(emergencyContact);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
