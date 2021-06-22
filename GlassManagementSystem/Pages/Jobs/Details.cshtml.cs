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
    public class DetailsModel : PageModel
    {
        private readonly GlassManagementSystem.Data.GlassManagementSystemContext _context;

        public DetailsModel(GlassManagementSystem.Data.GlassManagementSystemContext context)
        {
            _context = context;
        }

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
    }
}
