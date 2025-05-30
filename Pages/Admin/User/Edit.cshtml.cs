﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MealPlans.Models;

namespace MealPlans.Pages.Admin.User
{
    public class EditModel : PageModel
    {
        private readonly MealPlans.Models.DB_Meal_Context _context;

        public EditModel(MealPlans.Models.DB_Meal_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblUser TblUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbluser =  await _context.TblUsers.FirstOrDefaultAsync(m => m.Id == id);
            if (tbluser == null)
            {
                return NotFound();
            }
            TblUser = tbluser;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUserExists(TblUser.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TblUserExists(int id)
        {
            return _context.TblUsers.Any(e => e.Id == id);
        }
    }
}
