using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MealPlans.Models;

public partial class DB_Meal_Context : DbContext
{
    public DB_Meal_Context()
    {
    }

    public DB_Meal_Context(DbContextOptions<DB_Meal_Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TblMeal> TblMeals { get; set; }

    public virtual DbSet<TblMealPlan> TblMealPlans { get; set; }

    public virtual DbSet<TblMealStatus> TblMealStatuses { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=213.252.245.139;Database=DB_MealPlans;user id=sa;password=Coolboy@123;Trusted_Connection=False; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblMeal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Meal__ACF6A63D12C84C1B");

            entity.ToTable("tbl_Meals");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<TblMealPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Meal__3214EC075DE5E588");

            entity.ToTable("tbl_MealPlan");

            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(30)
                .HasComputedColumnSql("(datename(weekday,[Date]))", false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Meal).WithMany(p => p.TblMealPlans)
                .HasForeignKey(d => d.MealId)
                .HasConstraintName("FK_tbl_MealPlan_tbl_Meals");

            entity.HasOne(d => d.Status).WithMany(p => p.TblMealPlans)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_tbl_MealPlan_tbl_MealStatus");

            entity.HasOne(d => d.User).WithMany(p => p.TblMealPlans)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_tbl_MealPlan_tbl_Users");
        });

        modelBuilder.Entity<TblMealStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Meal__3214EC076AC6C85F");

            entity.ToTable("tbl_MealStatus");

            entity.HasIndex(e => e.StatusName, "UQ__tbl_Meal__05E7698A575629BC").IsUnique();

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.StatusName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_User__1788CC4CEE0CF4D4");

            entity.ToTable("tbl_Users");

            entity.HasIndex(e => e.Email, "UQ__tbl_User__A9D10534C759ED62").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.PasswordHash).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
