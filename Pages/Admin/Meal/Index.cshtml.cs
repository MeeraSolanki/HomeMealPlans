using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlans.Models;

namespace MealPlans.Pages.Admin.Meal
{
    // ✅ Inheritance: IndexModel inherits from BaseMealModel (custom abstract class)
    public abstract class BaseMealModel : PageModel
    {
        // ✅ Abstraction: Abstract method - implementation will be different in child classes (Polymorphism)
        public abstract Task LoadMealsAsync();
    }

    public class IndexModel : BaseMealModel
    {
        // ✅ Encapsulation: Database context stored in private field
        private readonly MealPlans.Models.DB_Meal_Context _context;

        public IndexModel(MealPlans.Models.DB_Meal_Context context)
        {
            _context = context;
        }

        // ✅ Encapsulation: Exposed as Property, Data stored safely
        public IList<TblMeal> TblMeal { get; set; } = default!;

        // ✅ Polymorphism: Overriding abstract method from BaseMealModel
        public override async Task LoadMealsAsync()
        {
            TblMeal = await _context.TblMeals.ToListAsync();
        }

        // ✅ Abstraction: Caller does not know how data is loaded, only calls this method
        public async Task OnGetAsync()
        {
            await LoadMealsAsync(); // Calls overridden method
        }
    }
}
