using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quokka_App.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using WebApplication1.Areas.Identity.Pages.Account;
using WebApplication1.Areas.Identity.Data;


namespace Quokka_App.Pages
{
    public class LeaderListModel : PageModel
    {
        private ConnectionsString _db;

        public LeaderListModel(ConnectionsString db)
        {
            _db = db;
        }
        public string assignToMe { get; set; }
        public IEnumerable<UserClass> displayData { get; private set; }

        [BindProperty]
        public UserClass LeaderAssigned { get; set; }


        public async Task OnGet(string id)
        {
            displayData = await _db.AspNetUsers.ToListAsync();
        }
    }
    LeaderAssigned = await _db.AspNetUsers.FindAsync("12345");
}

public async Task<IActionResult> OnPost()
{
    if (ModelState.IsValid)
    {
        var UserFromDB = await _db.AspNetUsers.FindAsync(LeaderAssigned.UserName);
        UserFromDB.LeaderAssigned = LeaderAssigned.LeaderAssigned;

        await _db.SaveChangesAsync();
        return RedirectToPage("Ind");
    }
    else
    {
        return Page();
    }
}
    }
}