using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NorthwindWeb.Pages {
    public class CustomersModel : PageModel {
        private Northwind db;
        public CustomersModel(Northwind injectedContext) {
            db = injectedContext;
        }

        public IEnumerable<SortedList<string,string>> Customers { get; set; }

        public void OnGet() {
            ViewData["Title"] = "Northwind Web Site - Customers";

            Customers = db.Customers.Select(c => new SortedList<string,string>() {
                {"CustomerName", c.CompanyName},
                {"Country", c.Country},
                {"CustomerID", c.CustomerID}
            });
        }
    }
}