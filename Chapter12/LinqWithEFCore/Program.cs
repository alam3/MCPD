using System;
using static System.Console;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinqWithEFCore {
    class Program {
        static void Main(string[] args) {
            // FilterAndSort();
            // JoinCategoriesAndProducts();
            GroupJoinCategoriesAndProducts();
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

        static void JoinCategoriesAndProducts() {
            using (var db = new Northwind()) {
                // join every product to its category to return 77 matches
                var queryJoin = db.Categories.Join(
                    inner: db.Products,
                    outerKeySelector: category => category.CategoryID,
                    innerKeySelector: product => product.CategoryID,
                    resultSelector: (c, p) => new { c.CategoryName, p.ProductName, p.ProductID })
                    .OrderBy(cp => cp.CategoryName);
                foreach (var item in queryJoin) {
                    WriteLine("{0}: {1} is in {2}.",
                        arg0: item.ProductID,
                        arg1: item.ProductName,
                        arg2: item.CategoryName);
                }
            }
        }

        static void GroupJoinCategoriesAndProducts() {
            using (var db = new Northwind()) {
                // group all products by their category to return 8 matches
                var queryGroup = db.Categories.AsEnumerable().GroupJoin(
                    inner: db.Products,
                    outerKeySelector: category => category.CategoryID,
                    innerKeySelector: product => product.CategoryID,
                    resultSelector: (c, matchingProducts) => new {
                        c.CategoryName,
                        Products = matchingProducts.OrderBy(p => p.ProductName) });
                
                foreach (var item in queryGroup) {
                    WriteLine("{0} has {1} products.",
                        arg0: item.CategoryName,
                        arg1: item.Products.Count());
                    foreach (var product in item.Products) {
                        WriteLine($" {product.ProductName}");
                    }
                }
            }
        }

    }
}
