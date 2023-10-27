using C_proj_MKMN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using C_proj_MKMN.Data;
using Microsoft.AspNetCore.Authorization;

namespace C_proj_MKMN.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {

        private readonly UserManager<UserModel> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        

        public AdminPanelController(UserManager<UserModel> userManager)
        {
            this._userManager = userManager;
        }

        // GET: AdminPanelController
        public ActionResult GetUsers()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        public ActionResult Index()
        {
           
            return View();
        }

        // GET: AdminPanelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminPanelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminPanelController/Edit/5
        public async Task<IActionResult> EditUsers(string id)
        {
            if (id == null)
            {
                return NotFound(); // Handle the case where the user ID is not provided
            }

            var user = await _userManager.FindByIdAsync(id);
            Console.WriteLine(user);
            
            if (user == null)
            {
                return NotFound(); // Handle the case where the user is not found
            }

            return View(user); // Pass the user object to the view
        }

        public async Task<IActionResult> PatchUser(string id, UserModel updatedUser, String selectedRole)
        {
            selectedRole = Request.Form["role"];
            if (id != updatedUser.Id)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(id) || updatedUser == null)
            {
                return NotFound();
            }

            // Retrieve the existing user from the database
            var existingUser = await _userManager.FindByIdAsync(id);
          

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Id = updatedUser.Id; 
          
            //existingUser.PasswordLengthRequirement = updatedUser.PasswordLengthRequirement;
            //existingUser.Version = Guid.NewGuid().ToByteArray();
            existingUser.Email = updatedUser.Email;
            existingUser.NormalizedEmail = updatedUser.Email.ToUpper();
            existingUser.UserName = updatedUser.UserName;
            existingUser.NormalizedUserName = updatedUser.UserName.ToUpper();
            //existingUser.LockoutEnabled = updatedUser.LockoutEnabled;
            //existingUser.LockoutEnd = updatedUser.LockoutEnd;
            existingUser.EmailConfirmed = updatedUser.EmailConfirmed;
           
            if (!string.IsNullOrEmpty(selectedRole))
            {
                if (await _roleManager.RoleExistsAsync(selectedRole))
                {
                    // Remove the user from existing roles
                    var userRoles = await _userManager.GetRolesAsync(existingUser);
                    await _userManager.RemoveFromRolesAsync(existingUser, userRoles);

                    // Add the user to the selected role
                    await _userManager.AddToRoleAsync(existingUser, selectedRole);
                }
            }
            var result = await _userManager.UpdateAsync(existingUser);

            if (result.Succeeded)
            {
                // Handle successful update
                return RedirectToAction("GetUsers");
            }
            else
            {
                // Handle update failure, check result.Errors for error details
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("EditUsers", updatedUser); // Return to edit view with error messages
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUsers(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminPanelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminPanelController/Delete/5
        // GET: AdministrationController/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: AdministrationController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string? id)
        {
            if (_userManager.Users == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Users'  is null.");
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            return RedirectToAction(nameof(GetUsers));
        }
        private bool UserExists(string id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

