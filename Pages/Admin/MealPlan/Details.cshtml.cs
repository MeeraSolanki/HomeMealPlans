using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlans.Models;

namespace MealPlans.Pages.Admin.MealPlan
{
    public class DetailsModel : PageModel
    {
        private readonly DB_Meal_Context _context;

        public DetailsModel(DB_Meal_Context context)
        {
            _context = context;
        }

        public TblMealPlan TblMealPlan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblMealPlan = await _context.TblMealPlans
                .Include(x => x.Meal)
                .Include(x => x.Status)
                .Include(x => x.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (TblMealPlan == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
