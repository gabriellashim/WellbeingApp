using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the WebAppUser class
    // Attribute and properties for data collection. Made for user data in paralowie r-12.
    public class WebAppUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string SchoolID { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string AccountType { get; set; }
    }
}
