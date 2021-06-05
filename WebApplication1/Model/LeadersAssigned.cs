using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;

namespace Quokka_App.Model
{
    public class LeadersAssigned
    {
        [Key]
        public string Id { get; set; }
        public string leaderID { get; set; }
        public string studentID { get; set; }

    }
}
