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
    public class IndexModel : PageModel
    {
        private readonly GlassManagementSystem.Data.GlassManagementSystemContext _context;


       
        public int ID { get; set; }

        [FromRoute]
        public string GlassTypeList { get; set; }

        public IndexModel(GlassManagementSystem.Data.GlassManagementSystemContext context)
        {
            _context = context;

        }

        [BindProperty]
        public GlassItems GlassBody { get; set; }


        public IList<GlassItems> GlassItemList { get;set; }
        

        public async Task OnGetAsync(int? id, string GlassType)
        {

        GlassItemList = new List<GlassItems>();

            ID = (int)id;

            GlassTypeList = GlassType;

            if (id != null)
            {
                GlassItemList = await _context.GlassItems.Where(m => m.GlassID == id).ToListAsync();              
            } 
            else 
            {
                GlassItemList = await _context.GlassItems.ToListAsync();
            }          
        }
    }
}





