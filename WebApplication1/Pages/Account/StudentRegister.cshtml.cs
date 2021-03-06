using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Quokka_App.Model;

namespace Quokka_App.Pages.Account
{
    //[Authorize(Roles = "Administrator, Leader, Senior Leader")]
    public class StudentRegisterModel : PageModel
    {
        private readonly SignInManager<WebAppUser> _signInManager;
        private readonly UserManager<WebAppUser> _userManager;
        private readonly ILogger<StudentRegisterModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        //private readonly IEmailSender _emailSender;

        public StudentRegisterModel(
            UserManager<WebAppUser> userManager,
            SignInManager<WebAppUser> signInManager,
            ILogger<StudentRegisterModel> logger,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            //_emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "LastName")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "SchoolID")]
            public string SchoolID { get; set; }

            //[DataType(DataType.Text)]
            //[Display(Name = "AccountType")]
            //public string AccountType { get; set; }

            //[DataType(DataType.Text)]
            //[Display(Name = "LeaderAssigned")]
            //public string LeaderAssigned { get; set; }

            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new WebAppUser
                {
                    UserName = Input.SchoolID,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    Id = Input.SchoolID
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (!(await _roleManager.RoleExistsAsync("Student"))) 
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Student") { Id = "3" });
                    }
                    await _userManager.AddToRoleAsync(user, "Student");

                    // NOTE:
                    // Please activate this code if email authorisation is required
                    //_logger.LogInformation("User created a new account with password.");
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new {returnUrl = returnUrl });
                    //}
                    //else
                    //{
                    //    await _signInManager.SignInAsync(user, isPersistent: false);
                    //    return LocalRedirect(returnUrl);
                    //}
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
