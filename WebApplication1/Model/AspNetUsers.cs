using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Quokka_App.Model
{
    public class AspNetUsers
    {
        [Key]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string AccountType { get; set; }
        public string LeaderAssigned { get; set; }
    }
}

