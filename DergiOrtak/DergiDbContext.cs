using DergiOrtak.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DergiOrtak
{
    public class DergiDbContext : IdentityDbContext
    {
        public DergiDbContext(DbContextOptions<DergiDbContext> options)
           : base(options)
        {
        }

        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Dergi> Dergi { get; set; }
        public DbSet<Sayi> Sayi { get; set; }
        public DbSet<Makale> Makale { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kategori>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Dergi>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Sayi>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Makale>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
        }
    }
}
