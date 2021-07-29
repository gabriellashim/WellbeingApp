using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quokka_App.Model;

namespace Quokka_App.ViewModel
{
    public class ReportEmotionViewModel
    {
        public StudentReports ReportList { get; set; }
        public Emotion EmotionReported { get; set; }
    }
}
