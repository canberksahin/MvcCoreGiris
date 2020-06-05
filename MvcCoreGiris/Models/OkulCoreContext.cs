using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreGiris.Models
{
    public class OkulCoreContext : DbContext
    {
        public OkulCoreContext(DbContextOptions<OkulCoreContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.;database=OkulCoreContext;uid=sa;pwd=123;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kisi>().HasData(
                new Kisi { Id=1, KisiAd="Can"},
                new Kisi { Id=2, KisiAd="Canan"}
                );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Kisi> Kisiler { get; set; }
    }
}
