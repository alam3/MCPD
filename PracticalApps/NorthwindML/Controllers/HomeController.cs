﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindML.Models;

// Imports to implement ML Controller
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.Data;
using Microsoft.ML.Trainers;


namespace NorthwindML.Controllers
{
    public class HomeController : Controller
    {
        // Fields for the filename and countries datasets will be generated for
        private readonly static string datasetName = "dataset.txt";
        private readonly static string[] countries = new[] { "Germany", "UK", "USA" };

        // dependency services for Northwind data context and web host environment
        private readonly ILogger<HomeController> _logger;
        private readonly Northwind db;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, Northwind db, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.db = db;
            this.webHostEnvironment = webHostEnvironment;
        }

        // Private method to return the path to a file stored in the data folder
        private string GetDataPath(string file) {
            return Path.Combine(webHostEnvironment.ContentRootPath, "wwwroot", "Data", file);
        }

        // Private method to create an instance of the HomeIndexViewModel loaded with all the products 
        // from the Northwind database and indicating if the datasets have been created
        private HomeIndexViewModel CreateHomeIndexViewModel() {
            return new HomeIndexViewModel {
                Categories = db.Categories.Include(category => category.Products),
                // File class must be prefixed with System.IO because the ControllerBase class also has a File method
                GermanyDatasetExists = System.IO.File.Exists(GetDataPath("germany-dataset.txt")),
                UKDatasetExists = System.IO.File.Exists(GetDataPath("uk-dataset.txt")),
                USADatasetExists = System.IO.File.Exists(GetDataPath("usa-dataset.txt")),
            };
        }

        public IActionResult Index()
        {
            var model = CreateHomeIndexViewModel(); // create model and pass on
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Action method to generate the datasets for each country and then return the default Index view
        public IActionResult GenerateDatasets() {
            foreach (string country in countries) {
                IEnumerable<Order> ordersInCountry = db.Orders
                    // filter by country to create different datasets
                    .Where(order => order.Customer.Country == country)
                    .Include(order => order.OrderDetails)
                    .AsEnumerable(); // switch to client-side
                IEnumerable<ProductCobought> coboughtProducts = ordersInCountry.SelectMany(order => 
                    from lineItem1 in order.OrderDetails // cross-join
                    from lineItem2 in order.OrderDetails
                    select new ProductCobought {
                        ProductID = (uint) lineItem1.ProductID,
                        CoboughtProductID = (uint) lineItem2.ProductID
                    })
                    // exclude matches between a product and itself
                    .Where(p => p.ProductID != p.CoboughtProductID)
                    // remove duplicates by grouping by both values
                    .GroupBy(p => new { p.ProductID, p.CoboughtProductID })
                    .Select(p => p.FirstOrDefault())
                    // make it easier for humans to read results by sorting
                    .OrderBy(p => p.ProductID)
                    .ThenBy(p => p.CoboughtProductID);
                StreamWriter datasetFile = System.IO.File.CreateText(path: GetDataPath($"{country.ToLower()}-{datasetName}"));
                // tab-separated header
                datasetFile.WriteLine("ProductID\tCoboughtProductID");

                foreach (var item in coboughtProducts) {
                    datasetFile.WriteLine("{0}\t{1}", item.ProductID, item.CoboughtProductID);
                }
                datasetFile.Close();
            }
            var model = CreateHomeIndexViewModel();
            return View("Index", model);
        }
    }
}
