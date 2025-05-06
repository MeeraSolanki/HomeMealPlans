using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MealPlans.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnPost()
        {
            HttpContext.Session.Clear();

            // Clear authentication cookies/session
            HttpContext.SignOutAsync(); // If using Identity/Auth


            // Redirect to login page with logout flag
            return RedirectToPage("/Login", new { logout = true });
        }
    }
}
