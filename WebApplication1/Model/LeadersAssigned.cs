using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quokka_App.Model
{
    public class LeadersAssigned
    {
        [Key]
        public int Id { get; set; }
        public int leaderID { get; set; }
        public int studentID { get; set; }

    }
}
