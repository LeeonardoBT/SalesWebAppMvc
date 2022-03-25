using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebAppMvc.Models;

namespace SalesWebAppMvc.Data
{
    public class SalesWebAppMvcContext : DbContext
    {
        public SalesWebAppMvcContext (DbContextOptions<SalesWebAppMvcContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebAppMvc.Models.Department> Department { get; set; }
    }
}
