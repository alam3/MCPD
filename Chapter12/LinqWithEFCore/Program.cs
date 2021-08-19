using System;
using static System.Console;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinqWithEFCore {
    class Program {
        static void Main(string[] args) {
            FilterAndSort();
        }

        static void FilterAndSort() {
            using (var db = new Northwind()) {
                var query = db.Products
                    // query is a DbSet<Product>
                    .Where(product => product.UnitPrice < 10M)
                    // query is now an IQueryable<Product>
                    .OrderByDescending(product => product.UnitPrice)
                    // query is now an IOrderedQueryable<Product>
                    // Section: Projecting sequences into new types. In this case SELECT allows for a more efficient call
                    // to the 3 columns needed rather than all the columns
                    .Select(product => new { // anonymous type
                        product.ProductID,
                        product.ProductName,
                        product.UnitPrice
                    });


                WriteLine("Products that cost less than $10:");
                foreach (var item in query) {
                    WriteLine("{0}: {1} costs {2:$#,##0.00}",
                    item.ProductID, item.ProductName, item.UnitPrice);
                }
                WriteLine();
            }
        }

    }
}
