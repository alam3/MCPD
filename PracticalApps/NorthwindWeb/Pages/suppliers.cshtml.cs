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

        // public IEnumerable<string> SuppliersName { get; set; }
        // public IEnumerable<string[]> Suppliers { get; set; }
        public IEnumerable<SortedList<string,string>> Suppliers { get; set; }


        public void OnGet() {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            // Suppliers = new[] { // Commented out to not hardcode Suppliers data
            //     "Alpha Co", "Beta Limited", "Gamma Corp"
            // };

            // For using EntityFrameworkCore with ASP.NET
            // Getting supplier from the Northwind database
            // SuppliersName = db.Suppliers.Select(s => s.CompanyName).ToList();

            // Suppliers = db.Suppliers.Select(s => new string[] {s.CompanyName, s.Country, s.Phone});
            Suppliers = db.Suppliers.Select(s => new SortedList<string,string>() {
                {"CompanyName", s.CompanyName},
                {"Country", s.Country},
                {"Phone", s.Phone}
            });
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