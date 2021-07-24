using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quokka_App.Model
{
    [Keyless]
    public class LeaderAssignedReport
    {
        [Display(Name = "Check by")]
        [ForeignKey("Id")]
        public WebAppUser CheckedBy { get; set; }

        [Display(Name = "Report checked")]
        [ForeignKey("ReportID")]
        public StudentReports ReportChecked { get; set; }

        [Display(Name = "Assigned Date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? AssignedDate { get; set; }

        [Display(Name = "Date Completed")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CompleteDate { get; set; }
    }
}
