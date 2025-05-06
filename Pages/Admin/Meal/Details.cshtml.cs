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
    public class DetailsModel : PageModel
    {
        private readonly MealPlans.Models.DB_Meal_Context _context;

        public DetailsModel(MealPlans.Models.DB_Meal_Context context)
        {
            _context = context;
        }

        public TblMeal TblMeal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblmeal = await _context.TblMeals.FirstOrDefaultAsync(m => m.Id == id);
            if (tblmeal == null)
            {
                return NotFound();
            }
            else
            {
                TblMeal = tblmeal;
            }
            return Page();
        }
    }
}
