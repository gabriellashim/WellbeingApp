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

        //Database representation of user first name
        [PersonalData]
        [Column(TypeName = "nvarchar(100)", Order = 1)]
        [Display(Name = "First Name")]
        [Required]
        [MaxLength(100, ErrorMessage = "Wrong Input")] //Change later
        public string FirstName { get; set; }

        //Database representation of last name
        [PersonalData]
        [Column(TypeName = "nvarchar(100)", Order = 2)]
        [Display(Name = "Last Name")]
        [Required]
        [MaxLength(100, ErrorMessage = "Wrong Input")] //Change later
        public string LastName { get; set; }

        [PersonalData]
        [Column(Order = 3)]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = false;

        [Display(Name = "Date Created")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? AccountCreated { get; set; }

        public string AccountType { get; set; }

        public string LeaderAssigned { get; set; }
    }
}
