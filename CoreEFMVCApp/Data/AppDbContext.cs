﻿using CoreEFMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreEFMVCApp.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
