using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GlassManagementSystem.Data;
using GlassManagementSystem.Models;

namespace GlassManagementSystem.GlassItem
{
    public class CreateModel : PageModel
    {

  
        public string GlassTypeList { get; set; }


        [FromRoute]
        public int Id { get; set; }


        private readonly GlassManagementSystem.Data.GlassManagementSystemContext _context;

        public CreateModel(GlassManagementSystem.Data.GlassManagementSystemContext context)
        {
            _context = context;
        }

      
        public IActionResult OnGet(int? id, string GlassType)
        {
            GlassTypeList = GlassType;


            return Page();


        }

        [BindProperty]
        public GlassItems GlassItems { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string GlassType, int id)
        {

            GlassItems.GlassID = id;

            if (GlassType == "Mirror")
            {
                GlassItems.GlassType = "Mirror";
                
            }
            else if (GlassType == "SingleGlazing")
            {
                GlassItems.GlassType = "Single Glazing";
               
            }
            else if (GlassType == "DoubleGlazing")
            {
                GlassItems.GlassType = "Double Glazing";
                 
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }


            _context.GlassItems.Add(GlassItems);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = GlassItems.GlassID });
        }
    }
}
