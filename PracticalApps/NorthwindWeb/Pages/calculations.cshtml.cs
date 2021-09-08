using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Console;


namespace NorthwindWeb.Pages {
    public class CalculationsModel : PageModel {
        public List<int> Result { get; set; }
        
        [BindProperty]
        public int Multiplicand { get; set; }

        public void OnGet() {
            Multiplicand = 0;
            Result = new List<int>() { 0 };
        }

        public IActionResult OnPost() {
            WriteLine($"Post value: {Multiplicand}");
            Result = new List<int>();
            if (ModelState.IsValid) {
                for (int i = 1; i <= 12; i++) {
                    Result.Add(Multiplicand * i);
                }
            }
            return Page();
        }
    }
}