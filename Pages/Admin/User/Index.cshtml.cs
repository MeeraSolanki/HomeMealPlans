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
    public class IndexModel : PageModel
    {
        private readonly MealPlans.Models.DB_Meal_Context _context;

        public IndexModel(MealPlans.Models.DB_Meal_Context context)
        {
            _context = context;
        }

        public IList<TblUser> TblUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TblUser = await _context.TblUsers.ToListAsync();
        }
    }
}
