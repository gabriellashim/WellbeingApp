using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quokka_App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quokka_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebAppContext _context;

        public HomeController(WebAppContext context)
        {
            _context = context;
        }
        [AllowAnonymous]

        public IActionResult Index()
        {
            return View();
        }
    }
}
