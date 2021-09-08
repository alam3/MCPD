using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Console;

namespace NorthwindWeb.Pages {
    public class CustomerDetailsModel : PageModel {
        private Northwind db;
        public CustomerDetailsModel(Northwind injectedContext) {
            db = injectedContext;
        }

        public Customer CustomerDetails { get; set; }
        public IEnumerable<Order> CustomerOrders { get; set; }

        public void OnGet(string CustomerID) { // this needs to match the Key string in the dictionary sent thru 'asp-all-route-data'!
            // WriteLine($"passed value: {CustomerID}");
            CustomerDetails = db.Customers.Single(c => CustomerID.Equals(c.CustomerID));
            CustomerOrders = db.Orders.Where(o => CustomerID.Equals(o.CustomerID)).ToArray();
        }
    }
}