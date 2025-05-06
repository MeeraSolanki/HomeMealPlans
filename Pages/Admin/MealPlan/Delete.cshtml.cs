using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlans.Models;

namespace MealPlans.Pages.Admin.MealPlan
{
    public class DeleteModel : PageModel
    {
        private readonly MealPlans.Models.DB_Meal_Context _context;

        public DeleteModel(MealPlans.Models.DB_Meal_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblMealPlan TblMealPlan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblmealplan = await _context.TblMealPlans.FirstOrDefaultAsync(m => m.Id == id);

            if (tblmealplan == null)
            {
                return NotFound();
            }
            else
            {
                TblMealPlan = tblmealplan;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblmealplan = await _context.TblMealPlans.FindAsync(id);
            if (tblmealplan != null)
            {
                TblMealPlan = tblmealplan;
                _context.TblMealPlans.Remove(TblMealPlan);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
