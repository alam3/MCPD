using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
// For using EntityFrameworkCore with ASP.NET
using System.Linq;
using Packt.Shared;
// For manipulating data in Razor Pages with EntityFrameworkCore
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For Code-behind with Razor defining the suppliers page for the Northwind Website
namespace NorthwindWeb.Pages {
    public class SuppliersModel : PageModel {
        // For using EntityFrameworkCore with ASP.NET
        // Gets the Northwind database context
        private Northwind db;
        public SuppliersModel(Northwind injectedContext) {
            db = injectedContext;
        }

        // public IList<string> SuppliersName { get; set; }
        public IList<Supplier> Suppliers { get; set; } // List of Supplier-type items


        public void OnGet() {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            // Suppliers = new[] { // Commented out to not hardcode Suppliers data
            //     "Alpha Co", "Beta Limited", "Gamma Corp"
            // };

            // For using EntityFrameworkCore with ASP.NET
            // Getting supplier from the Northwind database
            // SuppliersName = db.Suppliers.Select(s => s.CompanyName).ToList();

            Suppliers = db.Suppliers.ToList(); // Gets the entire "Supplier" type object
            // TODO: What data type to use to store a projection of the query?
        }

        // For manipulating data in Razor Pages with EntityFrameworkCore
        // Property storing a supplier and method to add it if the model is valid
        [BindProperty] // helps connect HTML elements to properties in the Supplier class.
        public Supplier Supplier { get; set; }
        public IActionResult OnPost() {
            if (ModelState.IsValid) {
                db.Suppliers.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            return Page();
        }
    }
}