using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlassManagementSystem.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GlassManagementSystem.Services
{
    public interface IPageService
    {
        Task<List<Glass>> GetPaginatedResult(int currentPage, string searchstring, int pageSize);
        Task<int> GetCount(string searchString);
    }
    public class PageService : IPageService
    {

        private readonly GlassManagementSystem.Data.GlassManagementSystemContext _context;

        public async Task<List<Glass>> GetPaginatedResult(int currentPage, string searchString, int pageSize)
        {
            var data = await GetData(searchString);
            return data.OrderByDescending(d => d.ID).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<int> GetCount(string searchString)
        {
            var data = await GetData(searchString);
            return data.Count;
        }

        public PageService(GlassManagementSystem.Data.GlassManagementSystemContext context)
        {
            _context = context;
        }

        private async Task<List<Glass>> GetData(string SearchString)
        {

             List<Glass>Glass;

            if (!string.IsNullOrEmpty(SearchString))
            {
                Glass = await _context.Glass.Where(s => s.Name.Contains(SearchString)).ToListAsync();
                return (List<Glass>)Glass;
            }
            else
            {
                return await _context.Glass.ToListAsync();
            }
        }
    }
}
