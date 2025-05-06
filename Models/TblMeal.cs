using System;
using System.Collections.Generic;

namespace MealPlans.Models;

public partial class TblMeal
{
    public int Id { get; set; }

    public string? MealName { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<TblMealPlan> TblMealPlans { get; set; } = new List<TblMealPlan>();
}
