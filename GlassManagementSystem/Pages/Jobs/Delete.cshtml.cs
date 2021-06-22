using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlassManagementSystem.Data;
using GlassManagementSystem.Models;

namespace GlassManagementSystem
{
    public class DeleteModel : PageModel
    {
        private readonly GlassManagementSystem.Data.GlassManagementSystemContext _context;

        public DeleteModel(GlassManagementSystem.Data.GlassManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Glass Glass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Glass = await _context.Glass.FirstOrDefaultAsync(m => m.ID == id);

            if (Glass == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Glass = await _context.Glass.FindAsync(id);

            if (Glass != null)
            {
                _context.Glass.Remove(Glass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Glass");
        }
    }
}
