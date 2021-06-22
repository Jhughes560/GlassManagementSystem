using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlassManagementSystem.Data;
using GlassManagementSystem.Models;
using GlassManagementSystem.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GlassManagementSystem
{
    public class IndexModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 8;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));


        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        private readonly PageService _personService;

        public IndexModel(PageService personService)
        {     
            _personService = personService;
        }

        public List<Glass> Glass { get;set; }


        public async Task OnGetAsync()
        {
            Glass = await _personService.GetPaginatedResult(CurrentPage, SearchString, PageSize);
            Count = await _personService.GetCount(SearchString);
        }

    }
}
