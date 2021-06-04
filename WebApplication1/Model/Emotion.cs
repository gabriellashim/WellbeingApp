using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Quokka_App.Model
{
    public class Emotion
    {
        [Key]
        public int ID { get; set; }
        public string studentId { get; set; }
        public string feeling { get; set; }
        public DateTime date { get; set; }
        public string whenToSee { get; set; }
        public string description { get; set; }
    }
}
