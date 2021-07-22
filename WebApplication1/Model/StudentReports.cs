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
        public int ID { get; set; }

        [ForeignKey("FirstName")]
        public string StudentID { get; set; }

        public string Feeling { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReportDate { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public string StudentComment { get; set; }

        [Column(Order = 7)]
        [Display(Name = "Completed")]
        public bool? IsComplete { get; set; } = true;


        [Column(Order = 3)]
        [Display(Name = "Assigned Date")]
        [DisplayFormat(DataFormatString = "{0:DD/MM/YYYY}")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AssignedDate { get; set; }

        [Column(Order = 4)]
        [Display(Name = "Complete Date")]
        [DisplayFormat(DataFormatString = "{0:DD/MM/YYYY}")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CompleteDate { get; set; }

        //[Column(Order = 2)]
        //[Display(Name = "Assigned to")]
        //[ForeignKey("FirstName")]
        //public WebAppUser AssignedTo { get; set; } //Should be the fname or id or leader

        [Column(Order = 9)]
        [Display(Name = "Priority")]
        public int Priority { get; set; }

        [Column(Order = 8)]
        [Display(Name = "selected emotion")]
        public string SelectedEmotion { get; set; }
    }
}
