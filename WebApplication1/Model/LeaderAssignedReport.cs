using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quokka_App.Model
{
    
    public class LeaderAssignedReport
    {

        [Display(Name = "Leader ID")]
        public string LeaderID { get; set; }

        [Display(Name = "Report ID")]
        public int ReportID { get; set; }

        [Display(Name = "Assigned Date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? AssignedDate { get; set; }

        [Display(Name = "Date Completed")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CompleteDate { get; set; }

        //Navigation Properties
        public virtual WebAppUser ManyWebAppUser { get; set; }
        public virtual StudentReports ManyStudentReports { get; set; }

    }
}