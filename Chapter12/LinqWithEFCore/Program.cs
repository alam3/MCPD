using System;
using static System.Console;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml.Linq; // Generating XML using LINQ to XML

namespace LinqWithEFCore {
    class Program {
        static void Main(string[] args) {
            // FilterAndSort();
            // JoinCategoriesAndProducts();
            // GroupJoinCategoriesAndProducts();
            // AggregateProducts();
            // CustomExtensionMethods();
            OutputProductsAsXml();
        }

        // static void FilterAndSort() { // Original method
        //     using (var db = new Northwind()) {
        //         var query = db.Products
        //             // query is a DbSet<Product>
        //             .Where(product => product.UnitPrice < 10M)
        //             // query is now an IQueryable<Product>
        //             .OrderByDescending(product => product.UnitPrice)
        //             // query is now an IOrderedQueryable<Product>
        //             // Section: Projecting sequences into new types. In this case SELECT allows for a more efficient call
        //             // to the 3 columns needed rather than all the columns
        //             .Select(product => new { // anonymous type
        //                 product.ProductID,
        //                 product.ProductName,
        //                 product.UnitPrice
        //             });

        //         WriteLine("Products that cost less than $10:");
        //         foreach (var item in query) {
        //             WriteLine("{0}: {1} costs {2:$#,##0.00}",
        //             item.ProductID, item.ProductName, item.UnitPrice);
        //         }
        //         WriteLine();
        //     }
        // }

        static void FilterAndSort() { // Method using custom chainable LINQ extension method
            using (var db = new Northwind()) {
                var query = db.Products
                    // query is a DbSet<Product>
                    .ProcessSequence()
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

        static void AggregateProducts() {
            using (var db = new Northwind()) {
                WriteLine("{0,-25} {1,10}", arg0: "Product count:", arg1: db.Products.Count());
                WriteLine("{0,-25} {1,10:$#.##0.00}", "Highest product price:", db.Products.Max(p => p.UnitPrice));
                WriteLine("{0,-25} {1,10:N0}", "Sum of units in stock:", db.Products.Sum(p => p.UnitsInStock));
                WriteLine("{0,-25} {1,10:N0}", "Sum of units on order:", db.Products.Sum(p => p.UnitsOnOrder));
                WriteLine("{0,-25} {1,10:$#.##0.00}", "Average unit price:", db.Products.Average(p => p.UnitPrice));
                WriteLine("{0,-25} {1,10:$#.##0.00}", "Value of units in stock:", db.Products.AsEnumerable()
                                                                                             .Sum(p => p.UnitPrice * p.UnitsInStock));
            }
        }

        // Using the methods in the custom LINQ extension
        static void CustomExtensionMethods() {
            using(var db = new Northwind()) {
                WriteLine("Mean units in stock: {0:N0}", db.Products.Average(p => p.UnitsInStock));
                WriteLine("Mean unit price: {0:$#,##0.00}", db.Products.Average(p => p.UnitPrice));

                WriteLine("Median units in stock: {0:N0}", db.Products.Median(p => p.UnitsInStock));
                WriteLine("Median unit price: {0:$#,##0.00}", db.Products.Median(p => p.UnitPrice));

                WriteLine("Mode units in stock: {0:N0}", db.Products.Mode(p => p.UnitsInStock));
                WriteLine("Mode unit price: {0:$#,##0.00}", db.Products.Mode(p => p.UnitPrice));
            }
        }

        // Generating XML using LINQ to XML
        static void OutputProductsAsXml() {
            using (var db = new Northwind()) {
                var productsForXml = db.Products.ToArray();
                var xml = new XElement("products", from p in productsForXml
                                                   select new XElement("product",
                                                     new XAttribute("id", p.ProductID),
                                                     new XAttribute("price", p.UnitPrice),
                                                     new XElement("name", p.ProductName)));
                WriteLine(xml.ToString());
            }
        }

    }
}
