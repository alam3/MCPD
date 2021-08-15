using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies; // Import namespace to use Lazy Loading

namespace Packt.Shared {
    public class Northwind : DbContext {
        // Northwind class represents the database
        // Using EF Core requires inheriting from DbContext, which translates/generates SQL statements from C# code

        // these properties, using DbSet<t>, map to tables in the database
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        // Use OnConfiguring to set the database connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
            // optionsBuilder.UseSqlite($"Filename={path}");
            optionsBuilder.UseLazyLoadingProxies().UseSqlite($"Filename={path}"); // Enable use of Lazy Loading
            // ^ Notice how running the program results on more round trip queries against the database vs. Eager Loading
        }

        // Required overridden method for writing Fluent API statements
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // example of using Fluent API instead of attributes to limit the length of a category name to 15
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired() // NOT NULL
                .HasMaxLength(15);
            // added to "fix" the lack of decimal support in SQLite
            modelBuilder.Entity<Product>()
                .Property(product => product.Cost)
                .HasConversion<double>();

            // global filter to remove discontinued products
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.Discontinued);
        }

    }
}