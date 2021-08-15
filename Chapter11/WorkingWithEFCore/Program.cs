﻿using System;
using static System.Console;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.Logging; // Used for logging
using Microsoft.EntityFrameworkCore.Infrastructure; // Used for logging
using Microsoft.Extensions.DependencyInjection; // Used for logging

namespace WorkingWithEFCore {
    class Program {
        static void Main(string[] args) {
            QueryingCategories();
            // FilteredIncludes();
            // QueryingProducts();
            // QueryingWithLike();
        }

        static void QueryingCategories() {
            using (var db = new Northwind()) {
                // for logging
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                WriteLine("Categories and how many products the have:");
                // a query to get all categories and their related products
                IQueryable<Category> cats = db.Categories;
                    // .Include(c => c.Products); 
                    // ^ Commented out to remove eager loading; notice all results are 0, as only the Categories are loaded
                foreach (Category c in cats) {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
                }
            }
        }

        static void FilteredIncludes() {
            using (var db = new Northwind()) {
                WriteLine("Enter a minimum for units in stock: ");
                string UnitsInStock = ReadLine();
                int stock = int.Parse(UnitsInStock);
                IQueryable<Category> cats = db.Categories
                    .Include(c => c.Products.Where(p => p.Stock >= stock));

                // Output generated SQL Statements
                WriteLine($"ToQueryString: {cats.ToQueryString()}");

                foreach (Category c in cats) {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock} units in stock.");
                    foreach (Product p in c.Products) {
                        WriteLine($"  {p.ProductName} has {p.Stock} units in stock.");
                    }
                }
            }
        }

        static void QueryingProducts() {
            using (var db = new Northwind()) {
                // for logging
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                WriteLine("Products that cost more than a price, highest at the top.");
                string input;
                decimal price;
                do {
                    WriteLine("Enter a product price: ");
                    input = ReadLine();
                } while (!decimal.TryParse(input, out price));

                IQueryable<Product> prods = db.Products
                    .Where(p => p.Cost > price)
                    .OrderByDescending(p => p.Cost);

                foreach (Product p in prods) {
                    WriteLine($"{p.ProductID}: {p.ProductName} costs {p.Cost:C2} and has {p.Stock} in stock");
                }
            }
        }

        static void QueryingWithLike() {
            using (var db = new Northwind()) {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                Write("Enter part of a product name: ");
                string input = ReadLine();
                IQueryable<Product> prods = db.Products
                    .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
                foreach (Product p in prods) {
                    WriteLine($"{p.ProductName} has {p.Stock} units in stock. Discontinued? {p.Discontinued}");
                }
            }
        }

    }
}
