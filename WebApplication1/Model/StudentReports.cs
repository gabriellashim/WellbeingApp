using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quokka_App.Model
{
    public class StudentReports
    {
        [Key]
        [Required]
        [Display(Name = "Report ID")]
        public int ID { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Reported")]
        [DisplayFormat(DataFormatString = "{0:DD/MM/YYYY}")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? ReportDate { get; set; }

        [Display(Name = "Student Comment")]
        public string StudentComment { get; set; }

        [Display(Name = "Appointment Date")]
        public string AppointmentDate { get; set; }

        [Column(Order = 4)]
        [Display(Name = "Complete Date")]
        [DisplayFormat(DataFormatString = "{0:DD/MM/YYYY}")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CompleteDate { get; set; }

        [Column(Order = 7)]
        [Display(Name = "Completed")]
        public bool? IsComplete { get; set; } = false;

        //Navigation Properties 

        //Relation to LeaderChecked table
        public virtual List<LeaderChecked> SRLeaderChecked { get; set; }

        //Relation to LeaderAssignment table
        public virtual List<LeaderAssignedReport> SRLeaderAssigned { get; set; }

        //User ID of the Assignee and leader
        [Display(Name = "Leader ID")]
        public string UserID { get; set; }
        public string ReporterID { get; set; }
        public virtual WebAppUser SRWebAppUser { get; set; }

        //Collects data from the student emotion table
        [Display(Name = "Emotion ID")]
        public int Feeling { get; set; }
        public virtual Emotion SREmotion{ get; set; }

       

    }
}