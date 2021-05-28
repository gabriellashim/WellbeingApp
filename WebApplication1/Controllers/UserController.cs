using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Areas.Identity.Data;


namespace Quokka_App.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<WebAppUser> userManager;
        public UserController(UserManager<WebAppUser> userManager) {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View(users);
        }
    }
}
