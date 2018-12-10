using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.ViewModels;
using OnlineShopping.Models;
using OnlineShopping.HelperUser;
using Microsoft.Extensions.Configuration;

namespace OnlineShopping.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<ArticleBuyingHistory> BuyingHistory { get; set; }
        public DbSet<Artikl> Artikli { get; set; }
        public DbSet<Kategorija> Kategorije { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
