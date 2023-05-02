﻿using Microsoft.EntityFrameworkCore;
using FullStackAPI.Models;

namespace FullStackAPI.Data
{
    public class FullStackDbContext : DbContext
    { 
        public FullStackDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
