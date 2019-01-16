using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppTestProject.HelperTestClasses
{
    class FakeDbContext: ApplicationDbContext
    {
        public FakeDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Shopping;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
