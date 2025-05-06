using System;
using System.Collections.Generic;

namespace MealPlans.Models;

public partial class TblMealStatus
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<TblMealPlan> TblMealPlans { get; set; } = new List<TblMealPlan>();
}
