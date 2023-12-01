// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using C_proj_MKMN.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;
using C_proj_MKMN.Data;
using C_proj_MKMN.Migrations;

namespace C_proj_MKMN.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<UserModel> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly ApplicationDbContext _db;
        private int X;
        private string resultPassword;

        public LoginModel(SignInManager<UserModel> signInManager, ILogger<LoginModel> logger, ApplicationDbContext db)
        {
            _signInManager = signInManager;
            _logger = logger;
            _db = db;
           

        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            public InputModel()
            {
                // Generate 'a' based on the length of the username
                VariableA = 0; // Default value, adjust as needed
                //VariableX = new Random().Next(1, 20); // Default value, adjust as needed
            }

            [Required]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Generated Password")]
            public string GeneratedPassword { get; set; }

            [Required]
            [Display(Name = "Variable A")]
            public int VariableA { get; set; }

            [Required]
            [Display(Name = "Variable X")]
            public int VariableX { get; set; }


            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
        

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            Input ??= new InputModel();



            if(Input.VariableX == 0)
            {
               Input.VariableX = 1;
            }
            Input.VariableX = new Random().Next(1, 200);
            HttpContext.Session.SetInt32("VariableX", Input.VariableX);
            //int VariableA = Input.Username?.Length??1;

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                int a = Input.Username.Length;
                int x = HttpContext.Session.GetInt32("VariableX") ?? 1;
         
                string expectedGeneratedPassword = GeneratePassword(a,x);

                if (Input.GeneratedPassword != expectedGeneratedPassword)
                {
                    ModelState.AddModelError(nameof(Input.GeneratedPassword), "Invalid generated password");
                    return RedirectToPage("./AccessDenied");
                }

               
                var result = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    if (Input.Username == "ADMIN")
                    {
                        var log = new LogListModel
                        {
                            UserName = Input.Username,
                            Log = "Logowanie Admin",
                            Opis = "Successful login",
                            DateTime = DateTime.Now
                        };

                        _db.LogListModels.Add(log);
                        _db.SaveChanges();
                        return LocalRedirect("/AdminPanel/GetUsers"); // Przykładowa akcja dla admina
                    }
                    else
                    {
                        var log = new LogListModel
                        {
                            UserName = Input.Username,
                            Log = $"Logowanie {Input.Username}",
                            Opis = "Successful login",
                            DateTime = DateTime.Now
                        };

                        _db.LogListModels.Add(log);
                        _db.SaveChanges();
                        return LocalRedirect("~/Identity/Account/Manage/ChangePassword");

                    }

                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    var log = new LogListModel
                    {
                        UserName = Input.Username,
                        Log = $"Logowanie {Input.Username} nieudane",
                        Opis = "Login failed",
                        DateTime = DateTime.Now
                    };

                    _db.LogListModels.Add(log);
                    _db.SaveChanges();
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        private string GeneratePassword(int a, int x)
        {
            double wynik = (double)a / x;
            string result = wynik.ToString("0.00");
            
            // Implement logic to generate the password based on the a/x equation
            return result;
        }
    }
}
