using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LMProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Authors> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Books>()
            .HasMany(a => a.Authors)
            .WithMany(b => b.Books)
            .UsingEntity(j => j.ToTable("AuthorsBooks"));
        }
    }
}