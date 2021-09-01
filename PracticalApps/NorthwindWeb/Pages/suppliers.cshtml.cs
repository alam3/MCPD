using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;


// For Code-behind with Razor defining the suppliers page for the Northwind Website
namespace NorthwindWeb.Pages {
    public class SuppliersModel : PageModel {
        public IEnumerable<string> Suppliers { get; set; }
        public void OnGet() {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            Suppliers = new[] {
                "Alpha Co", "Beta Limited", "Gamma Corp"
            };
        }
    }
}