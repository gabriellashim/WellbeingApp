using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quokka_App.Model
{
    public class EmergencyContact
    {
        [Key]
        [Required]
        [Display(Name = "Contact ID")]
        public int ContactID { get; set; }

        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [Display(Name = "Contact Number")]
        public int ContactPhone { get; set; }
    }
}
