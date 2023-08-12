using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AliBookStoreApi.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FullAddress> FullAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(x => x.BookId);

            modelBuilder.Entity<Author>()
                .HasKey(x => x.AuthorId);

            modelBuilder.Entity<Category>()
                .HasKey(x => x.CategoryId);

            modelBuilder.Entity<Customer>()
                .HasKey(x => x.CusId);

            modelBuilder.Entity<FullAddress>()
                .HasKey(x => x.AddressId);
        }
    }
}