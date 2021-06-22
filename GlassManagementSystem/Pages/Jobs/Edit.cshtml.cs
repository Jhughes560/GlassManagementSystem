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

namespace GlassManagementSystem
{
    public class EditModel : PageModel
    {
        private readonly GlassManagementSystem.Data.GlassManagementSystemContext _context;

        public EditModel(GlassManagementSystem.Data.GlassManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Glass Glass { get; set; }


        [BindProperty]
        public DateTime Date { get; set; }

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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {

            Date = _context.Glass.Where(m => m.ID == id).Select(m => m.DateCreated).SingleOrDefault();

            Glass.DateCreated = Date;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Glass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GlassExists(Glass.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Glass");
        }

        private bool GlassExists(int id)
        {
            return _context.Glass.Any(e => e.ID == id);
        }
    }
}
