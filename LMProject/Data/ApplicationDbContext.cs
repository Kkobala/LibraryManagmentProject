using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
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

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole{
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole{
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}