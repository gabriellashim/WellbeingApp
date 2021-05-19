using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quokka_App.Model;

namespace Quokka_App.Controllers
{
    public class UserList : Controller
    {
        public IActionResult Index()
        {
            List<UserClass> users = new List<UserClass>();
            return View("Test",users);
        }
    }
}
