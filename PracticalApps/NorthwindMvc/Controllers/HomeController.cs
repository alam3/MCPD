using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindMvc.Models;
// Querying a database and using display templates
using Microsoft.EntityFrameworkCore; // Adds the "Include" extension method
// Making controller action methods asynchronous
using System.Threading.Tasks;

// Imports for Northwind
using Packt.Shared;

// Imports for HTTP Client and JSON handling
using System.Net.Http;
using System.Net.Http.Json;

namespace NorthwindMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Field to store reference to Northwind instance and constructor initialization
        private Northwind db;

        // Field to store the HTTP Client Factory
        private readonly IHttpClientFactory clientFactory;
        public HomeController(ILogger<HomeController> logger, Northwind injectedContext, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            db = injectedContext;
            clientFactory = httpClientFactory;
        }

        // public IActionResult Index() // not asynchronous
        // Making controller action methods asynchronous
        public async Task<IActionResult> Index()
        {
            // Create instance of the view model for this method
            var model = new HomeIndexViewModel { 
                VisitorCount = (new Random()).Next(1, 1001),
                // Categories = db.Categories.ToList(),
                // Products = db.Products.ToList()
                Categories = await db.Categories.ToListAsync(), // asynchronous
                Products = await db.Products.ToListAsync() // asynchronous
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
        // public IActionResult ProductDetail(int? id) { // not asynchronous
        // Making controller action methods asynchronous
        public async Task<IActionResult> ProductDetail(int? id) {
            // Model binding automatically matches 'id' passed in the route with a parameter named 'id' in the method.
            if (!id.HasValue) {
                return NotFound("You must pass a product ID in the route, for example, /Home/ProductDetail/21");
            }

            // var model = db.Products.SingleOrDefault(p => p.ProductID == id);
            var model = await db.Products.SingleOrDefaultAsync(p => p.ProductID == id); // asynchronous

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

        // Querying a database and using display templates
        public IActionResult ProductsThatCostMoreThan(decimal? price) {
            if (!price.HasValue) {
                return NotFound("You must pass a product price in the query string, for example, /Home/ProductsThatCostMoreThan?price=50");
            }

            IEnumerable<Product> model = db.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Where(p => p.UnitPrice > price);
            if (model.Count() == 0) {
                return NotFound($"No products cost more than {price:C}.");
            }

            ViewData["MaxPrice"] = price.Value.ToString("C");
            return View(model); // pass model to view
        }

        // Call Northwind service, fetch all customers, and pass to a view
        public async Task<IActionResult> Customers(string country) {
            string uri;
            if (string.IsNullOrEmpty(country)) {
                ViewData["Title"] = "All Customers Worldwide";
                uri = "api/customers/";
            } else {
                ViewData["Title"] = $"Customers in {country}";
                uri = $"api/customers/?country={country}";
            }

            var client = clientFactory.CreateClient(name: "NorthwindService");
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: uri);
            HttpResponseMessage response = await client.SendAsync(request);
            var model = await response.Content.ReadFromJsonAsync<IEnumerable<Customer>>();
            return View(model);
        }
    }
}
