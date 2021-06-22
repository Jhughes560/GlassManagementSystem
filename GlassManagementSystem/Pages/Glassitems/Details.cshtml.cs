using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlassManagementSystem.Data;
using GlassManagementSystem.Models;

namespace GlassManagementSystem.GlassItem
{
    public class DetailsModel : PageModel
    {
        private readonly GlassManagementSystem.Data.GlassManagementSystemContext _context;

        public DetailsModel(GlassManagementSystem.Data.GlassManagementSystemContext context)
        {
            _context = context;
        }


        [BindProperty]
        public GlassItems GlassItems { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GlassItems = await _context.GlassItems.FirstOrDefaultAsync(m => m.GlassID == id);

            if (GlassItems == null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}
