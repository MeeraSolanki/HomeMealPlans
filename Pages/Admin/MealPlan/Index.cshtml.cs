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
    public class IndexModel : PageModel
    {
        private readonly MealPlans.Models.DB_Meal_Context _context;

        public IndexModel(MealPlans.Models.DB_Meal_Context context)
        {
            _context = context;
        }

        public IList<TblMealPlan> TblMealPlan { get; set; } = new List<TblMealPlan>();
        public IList<TblMealPlan> UpcomingMeals { get; set; } = new List<TblMealPlan>();

        // Lists for dropdown filters
        public List<TblMealStatus> StatusList { get; set; }
        public List<TblMeal> MealList { get; set; }
        public List<TblUser> UserList { get; set; }

        // Filter properties (Only for "All Meal Plans")
        [BindProperty(SupportsGet = true)]
        public int? SelectedMonth { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SelectedStatus { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SelectedMeal { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SelectedUser { get; set; }

        public async Task OnGetAsync()
        {
            // Load dropdown data
            StatusList = await _context.TblMealStatuses.ToListAsync();
            MealList = await _context.TblMeals.ToListAsync();
            UserList = await _context.TblUsers.ToListAsync();

            // Get today's date and the next two days in DateOnly format
            var today = DateOnly.FromDateTime(DateTime.Today);
            var nextTwoDays = DateOnly.FromDateTime(DateTime.Today.AddDays(2));

            // Fetch upcoming meals (No Filters Applied Here)
            UpcomingMeals = await _context.TblMealPlans
                .Include(t => t.Meal)
                .Include(t => t.Status)
                .Include(t => t.User)
                .Where(m => m.Date >= today && m.Date <= nextTwoDays && m.Status.StatusName == "Planned")
                .OrderBy(m => m.Date)
                .ToListAsync();

            // Query for "All Meal Plans" (Apply Filters)
            var query = _context.TblMealPlans
                .Include(t => t.Meal)
                .Include(t => t.Status)
                .Include(t => t.User)
                .AsQueryable();

            // Apply filters for "All Meal Plans"
            if (SelectedMonth.HasValue)
            {
                query = query.Where(mp => mp.Date.Month == SelectedMonth);
            }

            if (SelectedStatus.HasValue)
            {
                query = query.Where(mp => mp.StatusId == SelectedStatus);
            }

            if (SelectedMeal.HasValue)
            {
                query = query.Where(mp => mp.MealId == SelectedMeal);
            }

            if (SelectedUser.HasValue)
            {
                query = query.Where(mp => mp.UserId == SelectedUser);
            }

            // Fetch filtered data for "All Meal Plans"
            TblMealPlan = await query.ToListAsync();
        }
    }
}
