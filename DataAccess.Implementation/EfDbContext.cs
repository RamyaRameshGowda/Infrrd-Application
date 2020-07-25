using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Implementation
{
    public class EfDbContext:DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options)
           : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<DepartmentDetails> DepartmentDetails { get; set; }
    }
}
