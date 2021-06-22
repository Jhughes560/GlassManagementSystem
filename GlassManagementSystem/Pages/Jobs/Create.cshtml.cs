using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GlassManagementSystem.Data;
using GlassManagementSystem.Models;

namespace GlassManagementSystem
{
    public class CreateModel : PageModel
    {
        private readonly GlassManagementSystem.Data.GlassManagementSystemContext _context;

        public CreateModel(GlassManagementSystem.Data.GlassManagementSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Glass Glass { get; set; }

        [BindProperty]
        public GlassItems GlassItems { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
           // if (!ModelState.IsValid)
            //{
            //    return Page();
            //



            GlassItems.GlassID = Glass.ID;
            Glass.DateCreated = DateTime.Now;

            _context.Glass.Add(Glass);
            await _context.SaveChangesAsync();

            //_context.GlassItems.Add(GlassItems);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Glass");
        }
    }
}
