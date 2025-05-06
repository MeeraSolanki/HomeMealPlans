using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MealPlans.Models; // or your actual namespace
using System.Linq;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace MealPlans.Pages
{
    public class LoginModel : PageModel
    {
        private readonly MealPlans.Models.DB_Meal_Context _context;

        public LoginModel(MealPlans.Models.DB_Meal_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public string LogoutMessage { get; set; }

        public void OnGet(bool logout = false)
        {
            if (logout)
            {
                ModelState.Clear();
                LogoutMessage = "You have been logged out successfully.";
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = _context.TblUsers.FirstOrDefault(u => u.Email == Email);

            if (user == null || user.PasswordHash != Password)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return Page();
            }

            // ✅ Store user in session
            HttpContext.Session.SetString("UserId", user.Id.ToString());

            TempData["LoginSuccess"] = "Logged in successfully!";
            return RedirectToPage("/Index"); // Redirect to your desired page
        }

    }
}


