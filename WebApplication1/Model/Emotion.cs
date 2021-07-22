using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quokka_App.Model
{
    public class Emotion
    {
        [Key]
        [Display(Name = "Emotion ID")]
        [Required]
        public int EmotionID { get; set; }

        [Display(Name = "Student Emotion")]
        [Required]
        public string StudentEmotion { get; set; }
    }
}
