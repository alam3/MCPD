using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindMvc.Models;

// Imports for Northwind
using Packt.Shared;

namespace NorthwindMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Field to store reference to Northwind instance and constructor initialization
        private Northwind db;
        public HomeController(ILogger<HomeController> logger, Northwind injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        public IActionResult Index()
        {
            // Create instance of the view model for this method
            var model = new HomeIndexViewModel { 
                VisitorCount = (new Random()).Next(1, 1001),
                Categories = db.Categories.ToList(),
                Products = db.Products.ToList()
            };

            return View(model); // pass model to view
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
    }
}
