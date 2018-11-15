using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Data
{
    public class ArtiklContext :DbContext
    {
        public ArtiklContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DbSet<Artikl> Artikli { get; set; }
        public DbSet<Kategorija> Kategorije { get; set; }
        public IConfiguration Configuration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
