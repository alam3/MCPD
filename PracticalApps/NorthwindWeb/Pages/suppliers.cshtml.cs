using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
// For using EntityFrameworkCore with ASP.NET
using System.Linq;
using Packt.Shared;


// For Code-behind with Razor defining the suppliers page for the Northwind Website
namespace NorthwindWeb.Pages {
    public class SuppliersModel : PageModel {
        // For using EntityFrameworkCore with ASP.NET
        // Gets the Northwind database context
        private Northwind db;
        public SuppliersModel(Northwind injectedContext) {
            db = injectedContext;
        }

        public IEnumerable<string> Suppliers { get; set; }
        public void OnGet() {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            // Suppliers = new[] { // Commented out to not hardcode Suppliers data
            //     "Alpha Co", "Beta Limited", "Gamma Corp"
            // };

            // For using EntityFrameworkCore with ASP.NET
            // Getting supplier from the Northwind database
            Suppliers = db.Suppliers.Select(s => s.CompanyName);
        }
    }
}