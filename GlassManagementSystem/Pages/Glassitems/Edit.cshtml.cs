using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlassManagementSystem.Data;
using GlassManagementSystem.Models;

namespace GlassManagementSystem.GlassItem
{


    public class EditModel : PageModel
    {
        private readonly GlassManagementSystem.Data.GlassManagementSystemContext _context;

        public EditModel(GlassManagementSystem.Data.GlassManagementSystemContext context)
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

            GlassItems = await _context.GlassItems.FirstOrDefaultAsync(m => m.ID == id);

            if (GlassItems == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string GlassType, int id)
        {

            GlassItems.GlassID = _context.GlassItems.Where(m => m.ID == id).Select(m => m.GlassID).SingleOrDefault(); ;

            if (GlassType == "Mirror")
            {
                GlassItems.GlassType = "Mirror";

            }
            else if (GlassType == "Single Glazing")
            {
                GlassItems.GlassType = "Single Glazing";

            }
            else if (GlassType == "Double Glazing")
            {
                GlassItems.GlassType = "Double Glazing";

            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GlassItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GlassItemsExists(GlassItems.GlassID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { id = GlassItems.GlassID });
        }

       

        private bool GlassItemsExists(int id)
        {
            return _context.GlassItems.Any(e => e.GlassID == id);

           
        }
    }
}
