using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlans.Models;

namespace MealPlans.Pages.Admin.User
{
    public class DetailsModel : PageModel
    {
        private readonly MealPlans.Models.DB_Meal_Context _context;

        public DetailsModel(MealPlans.Models.DB_Meal_Context context)
        {
            _context = context;
        }

        public TblUser TblUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbluser = await _context.TblUsers.FirstOrDefaultAsync(m => m.Id == id);
            if (tbluser == null)
            {
                return NotFound();
            }
            else
            {
                TblUser = tbluser;
            }
            return Page();
        }
    }
}
