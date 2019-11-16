using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> CustomersTbl { get; set; }
        public DbSet<Author> AuthorTbl { get; set; }
        public DbSet<Book> BookTbl { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(e =>
            {
                e.HasKey(x => x.ID);
                e.Property(x => x.Name).IsRequired();
                e.Property(x => x.Email).IsRequired();
                e.Property(x => x.Address).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Author>(e =>
            {
                e.HasKey(x => x.ID);
                e.Property(x => x.Name).IsRequired();
                e.Property(x => x.Email).IsRequired();
            });

            modelBuilder.Entity<Book>(e =>
            {
                e.HasKey(x => x.ID);
                e.Property(x => x.Title).IsRequired();
                e.HasOne(x => x.Author).WithMany(x => x.books).HasForeignKey(x => x.AuthorID);
                //e.HasOne(x => x.Customer).WithMany(x => x.books).HasForeignKey(x => x.CustID);

            });
        }
    }
}
