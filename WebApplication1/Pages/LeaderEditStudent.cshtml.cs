using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quokka_App.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Quokka_App.Pages
{
    public class LeaderEditStudentModel : PageModel
    {
        private ConnectionsString _db;

        public LeaderEditStudentModel(ConnectionsString db)
        {
            _db = db;
        }

        public IEnumerable<UserClass> displayData { get; private set; }
        public UserClass UserClass { get; set; }

        #region snippet_OnGetPost
        public async Task<IActionResult> OnGetAsync(string id)
        {
            displayData = await _db.AspNetUsers.ToListAsync();

            if (id == null)
            {
                return NotFound();
            }

            UserClass = await _db.AspNetUsers.FindAsync(id);
    

            if (UserClass == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            var studentToUpdate = await _db.AspNetUsers.FindAsync(id);

            if (studentToUpdate == null)
            {
                return NotFound();
            }
  

            if (await TryUpdateModelAsync<UserClass> (
                studentToUpdate,
                "student",
                s => s.FirstName, s => s.LastName, s => s.AssignedTo))
            {
                _db.AspNetUsers.Update(studentToUpdate);
                _db.SaveChanges();
                //await _db.SaveChangesAsync();
                return RedirectToPage("./LeaderList");
            }
            return Page();
        }
        #endregion

    }
}