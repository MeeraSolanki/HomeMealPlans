using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MealPlans.Models;

namespace MealPlans.Pages.Admin.MealPlan
{
    public class EditModel : PageModel
    {
        private readonly MealPlans.Models.DB_Meal_Context _context;

        public EditModel(MealPlans.Models.DB_Meal_Context context)
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

            var tblmealplan =  await _context.TblMealPlans.FirstOrDefaultAsync(m => m.Id == id);
            if (tblmealplan == null)
            {
                return NotFound();
            }
            TblMealPlan = tblmealplan;
           ViewData["MealId"] = new SelectList(_context.TblMeals, "Id", "MealName");
           ViewData["StatusId"] = new SelectList(_context.TblMealStatuses, "Id", "StatusName");
           ViewData["UserId"] = new SelectList(_context.TblUsers, "Id", "Username");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblMealPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMealPlanExists(TblMealPlan.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TblMealPlanExists(int id)
        {
            return _context.TblMealPlans.Any(e => e.Id == id);
        }
    }
}
