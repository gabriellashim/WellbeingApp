using Quokka_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quokka_App.ViewModel
{
    public class UsersReportsViewModel
    {
        public WebAppUser ApplicationUser { get; set; }
        public List<StudentReports> AssignReport { get; set; }
    }
}
