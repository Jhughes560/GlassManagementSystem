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
    public class DeleteModel : PageModel
    {
        private readonly GlassManagementSystem.Data.GlassManagementSystemContext _context;

        public DeleteModel(GlassManagementSystem.Data.GlassManagementSystemContext context)
        {
            _context = context;
        }


        [FromRoute]
        public int Id { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {

            id = GlassItems.ID;

            GlassItems = await _context.GlassItems.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }

            if (GlassItems != null)
            {
                _context.GlassItems.Remove(GlassItems);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id = GlassItems.GlassID });
        }
    }
}
