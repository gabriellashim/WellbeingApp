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
    public class LeaderChecked
    {
        [Display(Name = "Check by")]
        [ForeignKey("Id")]
        public WebAppUser CheckedBy { get; set; }

        [Display(Name = "Report checked")]
        [ForeignKey("ReportID")]
        public StudentReports ReportBy { get; set; }

        [Display(Name = "Is Checked")]
        public bool IsChecked { get; set; } = false;

        [Display(Name = "Checked Date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? CheckedDate { get; set; }

    }
}
