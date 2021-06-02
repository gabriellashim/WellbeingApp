using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quokka_App.Model;

namespace Quokka_App.Pages
{
    public class StudentPageModel : PageModel
    {
        public void OnGet()
        {
        }

        public IEnumerable<Emotion> Emotions { get; set; }

    }
}
