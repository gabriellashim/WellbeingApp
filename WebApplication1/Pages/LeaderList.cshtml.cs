using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quokka_App.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

        public async Task OnGet()
        {
            displayData = await _db.AspNetUsers.ToListAsync();

        }
    }
}