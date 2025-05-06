using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MealPlans.Models;

namespace MealPlans.Pages.Admin.Meal
{
    public class CreateModel : PageModel
    {
        private readonly MealPlans.Models.DB_Meal_Context _context;

        public CreateModel(MealPlans.Models.DB_Meal_Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TblMeal TblMeal { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblMeals.Add(TblMeal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
