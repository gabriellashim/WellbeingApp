using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Quokka_App.Model
{ 
    public class WebAppUser : IdentityUser
    {

        [PersonalData]
        [Column(TypeName = "nvarchar(100)", Order = 1)]
        [Display(Name = "First Name")]
        [Required]
        [MaxLength(100, ErrorMessage = "Number of character exceeded")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)", Order = 2)]
        [Display(Name = "Last Name")]
        [Required]
        [MaxLength(100, ErrorMessage = "Number of character exceeded")]
        public string LastName { get; set; }

        [PersonalData]
        [Column(Order = 3)]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = false;

        [Display(Name = "Date Created")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? AccountCreated { get; set; }

        //Navigation Properties
        public virtual List<LeaderChecked> Userleaderchecked { get; set; }
        public virtual List<LeaderAssignedReport> UserLeaderAssigned { get; set; }
        public virtual List<StudentReports> UserStudentReport { get; set; }

    }
}