using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

namespace PacktFeatures.Pages {

    // Define a page model with an array of Employee entity instances loaded from the Northwind DB
    public class EmployeesPageModel : PageModel {

        private Northwind db;
        public EmployeesPageModel(Northwind injectedContext) {
            db = injectedContext;
        }

        public IEnumerable<Employee> Employees { get; set; }
        public void OnGet()
        {
            Employees = db.Employees.ToArray();
        }
    }
}
