using Quokka_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quokka_App.ViewModel
{
    public class UserReportViewModel
    {
        public WebAppUser AppUser { get; set; }
        public StudentReports Reports { get; set; }
    }
}
