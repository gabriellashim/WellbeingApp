using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quokka_App.Model
{
    
    public class LeaderChecked
    {
       
        [Display(Name = "Check by")]
        public string WebAppUserID { get; set; }

        [Display(Name = "Report checked")]
        public int StudentReportsID { get; set; }

        [Display(Name = "Checked Date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? CheckedDate { get; set; }

        [Display(Name = "Leader Comment")]
        public string LeaderComment { get; set; }

        //Navigation Properties
        public virtual WebAppUser ManyWebAppUser { get; set; }
        public virtual StudentReports ManyStudentReports { get; set; }
    }
}