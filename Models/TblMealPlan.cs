using System;
using System.Collections.Generic;

namespace MealPlans.Models;

public partial class TblMealPlan
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? MealId { get; set; }

    public string? FoodName { get; set; }

    public DateOnly Date { get; set; }

    public string? DayOfWeek { get; set; }

    public int? StatusId { get; set; }

    public string? Notes { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual TblMeal? Meal { get; set; }

    public virtual TblMealStatus? Status { get; set; }

    public virtual TblUser? User { get; set; }
}
