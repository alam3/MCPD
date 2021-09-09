using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Console;
using System.Numerics;


namespace NorthwindWeb.Pages {
    public class CalculationsModel : PageModel {
        public List<long> TimesTableResult { get; set; }
        public BigInteger FactorialResult { get; set; }
        List<long> fibonacciResult;
        public string FibonacciSequenceString { get; set; }

        [BindProperty]
        public long Multiplicand { get; set; }

        public CalculationsModel() {
            TimesTableResult = new List<long>();
            fibonacciResult = new List<long>();
            Multiplicand = 0;
        }

        public void OnGet() {
        }

        public IActionResult OnPost() {
            WriteLine($"Post value: {Multiplicand}");
            if (ModelState.IsValid) {
                for (int i = 1; i <= 12; i++) {
                    TimesTableResult.Add(Multiplicand * i);
                }

                FactorialResult = Factorial(Multiplicand);

                for (long i = 1; i <= Multiplicand; i++) {
                    fibonacciResult.Add(FibonacciTerm(i));
                }
                FibonacciSequenceString = string.Join(", ", fibonacciResult.ToArray());
            }
            return Page();
        }

        BigInteger Factorial(long inputNumber) {
            if (inputNumber < 1) {
                return 0;
            } else if (inputNumber == 1) {
                return 1;
            } else {
                checked {
                    return inputNumber * Factorial(inputNumber - 1);
                }
            }
        }

        long FibonacciTerm(long term) => term switch {
            1 => 0,
            2 => 1,
            _ => FibonacciTerm(term - 1) + FibonacciTerm(term - 2)
        };
    }
}