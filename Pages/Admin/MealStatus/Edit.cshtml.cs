using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MealPlans.Models;

namespace MealPlans.Pages.Admin.MealStatus
{
    public class EditModel : PageModel
    {
        private readonly MealPlans.Models.DB_Meal_Context _context;

        public EditModel(MealPlans.Models.DB_Meal_Context context)
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

            var tblmealstatus =  await _context.TblMealStatuses.FirstOrDefaultAsync(m => m.Id == id);
            if (tblmealstatus == null)
            {
                return NotFound();
            }
            TblMealStatus = tblmealstatus;
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

            _context.Attach(TblMealStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMealStatusExists(TblMealStatus.Id))
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

        private bool TblMealStatusExists(int id)
        {
            return _context.TblMealStatuses.Any(e => e.Id == id);
        }
    }
}
