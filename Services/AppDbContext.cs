using dotnet_app.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace dotnet_app.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
            public DbSet<Employee> Employees { get; set; }

        

    }
}
