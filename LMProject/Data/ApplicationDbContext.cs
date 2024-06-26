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
        public DbSet<AuthorsModel> Authors { get; set; }
        public DbSet<JoinTables> JoinedTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JoinTables>(x => x.HasKey(ab => new { ab.AuthorId, ab.BookId}));

            modelBuilder.Entity<JoinTables>()
                .HasOne(a => a.Author)
                .WithMany(b => b.AuthorsBooks)
                .HasForeignKey(ab => ab.AuthorId);

            modelBuilder.Entity<JoinTables>()
                .HasOne(b => b.Book)
                .WithMany(ab => ab.AuthorsBooks)
                .HasForeignKey(a => a.BookId);
        }
    }
}