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

        // Passing parameters using a route value ("id" in this case)
        public IActionResult ProductDetail(int? id) {
            // Model binding automatically matches 'id' passed in the route with a parameter named 'id' in the method.
            if (!id.HasValue) {
                return NotFound("You must pass a product ID in the route, for example, /Home/ProductDetail/21");
            }

            var model = db.Products.SingleOrDefault(p => p.ProductID == id);
            if (model == null) {
                return NotFound($"Product with ID of {id} not found.");
            }

            return View(model); // pass model to view and then return result
            // If the view is named after the action method (this method), and placed in the folder that matches the
            // controller name or a shared folder, then ASP.NET Core MVC can automatically find it.
            // The view here is in ../Views/Home/ProductDetail.cshtml
        }

        // Model binding examples
        public IActionResult ModelBinding() {
            return View(); // the page with a form to submit
        }
        // Without a [HttpPost] decoration, HTTP cannot differentiate between both ModelBinding() methods and an error is thrown.
        // The decoration indicates this method should be used for processing HTTP POST requests.
        [HttpPost]
        public IActionResult ModelBinding(Thing thing) {
            // return View(thing); // show the model bound thing; commented for showing a model validation example

            // Create instance of the view model. Validate model and store and array of error messages, then pass to view.
            var model = new HomeModelBindingViewModel {
                Thing = thing,
                HasErrors = !ModelState.IsValid,
                ValidationErrors = ModelState.Values
                    .SelectMany(state => state.Errors)
                    .Select(error => error.ErrorMessage)
            };
            return View(model);
        }
    }
}
