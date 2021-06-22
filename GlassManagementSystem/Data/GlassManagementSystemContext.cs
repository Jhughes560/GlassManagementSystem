using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlassManagementSystem.Models;

namespace GlassManagementSystem.Data
{
    public class GlassManagementSystemContext : DbContext
    {
        public GlassManagementSystemContext (DbContextOptions<GlassManagementSystemContext> options)
            : base(options)
        {
        }

        public DbSet<GlassManagementSystem.Models.Glass> Glass { get; set; }

        public DbSet<GlassManagementSystem.Models.GlassItems> GlassItems { get; set; }
    }
}
