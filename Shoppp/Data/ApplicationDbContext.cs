using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.ViewModels;
using OnlineShopping.Models;
using OnlineShopping.HelperUser;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace OnlineShopping.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<ArticleBuyingHistory> BuyingHistory { get; set; }
        public DbSet<Artikl> Articles { get; set; }
        public DbSet<Kategorija> Categories { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementType> AdvertisementTypes { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CategoryCharachteristic> CategoryCharachteristics { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<MessageBox> MessageBoxes { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<MessageBox>().HasKey(m => m.MessageBoxID);
            //builder.Entity<MessageBox>().HasOne(m => m.Reciver);
            //builder.Entity<MessageBox>().HasOne(m => m.Sender);
        }
    }
}
