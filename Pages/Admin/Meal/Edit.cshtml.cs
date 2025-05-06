using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlans.Models;

namespace MealPlans.Pages.Admin.Meal
{
    // ✅ Abstraction: EditModel hides database operations from UI logic
    public class EditModel : PageModel
    {
        // ✅ Encapsulation: The _context field is private and can only be accessed within this class
        private readonly MealPlans.Models.DB_Meal_Context _context;

        // ✅ Constructor Injection: Injecting DB context (Dependency Injection)
        public EditModel(MealPlans.Models.DB_Meal_Context context)
        {
            _context = context;
        }

        // ✅ Encapsulation: Property with automatic binding to Razor Page
        [BindProperty]
        public TblMeal TblMeal { get; set; } = default!;

        // ✅ Abstraction: This method abstracts away database queries 
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound(); // If no ID is given, return a 404 error
            }

            // ✅ Encapsulation: Querying database for the meal entry
            var tblmeal = await _context.TblMeals.FirstOrDefaultAsync(m => m.Id == id);
            if (tblmeal == null)
            {
                return NotFound();
            }
            TblMeal = tblmeal; // Assign data to the property

            return Page(); // Return the page
        }

        // ✅ Abstraction & Encapsulation: This method updates the meal details without exposing implementation
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) // ✅ Encapsulation: Checking for validation errors
            {
                return Page(); // If invalid, reload the page
            }

            // ✅ Encapsulation: Marking the entity as modified without exposing DB logic
            _context.Attach(TblMeal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(); // ✅ Encapsulation: Saving changes in the database
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMealExists(TblMeal.Id))
                {
                    return NotFound(); // If record not found, return 404
                }
                else
                {
                    throw; // Otherwise, throw an exception
                }
            }

            return RedirectToPage("./Index"); // Redirect to list page
        }

        // ✅ Encapsulation: A private helper method to check if a record exists
        private bool TblMealExists(int id)
        {
            return _context.TblMeals.Any(e => e.Id == id);
        }
    }
}
