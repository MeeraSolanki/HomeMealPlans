using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlans.Models;

namespace MealPlans.Pages.Admin.MealStatus
{
    public class DeleteModel : PageModel
    {
        private readonly MealPlans.Models.DB_Meal_Context _context;

        public DeleteModel(MealPlans.Models.DB_Meal_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblMealStatus TblMealStatus { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblmealstatus = await _context.TblMealStatuses.FirstOrDefaultAsync(m => m.Id == id);

            if (tblmealstatus == null)
            {
                return NotFound();
            }
            else
            {
                TblMealStatus = tblmealstatus;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblmealstatus = await _context.TblMealStatuses.FindAsync(id);
            if (tblmealstatus != null)
            {
                TblMealStatus = tblmealstatus;
                _context.TblMealStatuses.Remove(TblMealStatus);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
