using System;
using System.Collections.Generic;

namespace MealPlans.Models;

public partial class TblUser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<TblMealPlan> TblMealPlans { get; set; } = new List<TblMealPlan>();
}
