using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Models
{
    public class BookDBContext:DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options):base(options)
        {
        }
        public DbSet<Book> BookItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(e =>
            {
                e.HasKey(b => b.Id);
                e.Property(b => b.Id).HasDefaultValueSql("(newid())");
                e.Property(b => b.Name).IsRequired();
                e.Property(b => b.Author).IsRequired();
                e.Property(b => b.Price).IsRequired();
                e.Property(b => b.Popular).IsRequired();

            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
