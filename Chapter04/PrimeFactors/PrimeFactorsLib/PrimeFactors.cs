using System;
using System.Collections.Generic;

namespace PrimeFactorsLib {
    public class PrimeFactors {
        public List<int> PrimeFactorsCalc(int input) {
            List<int> primeFactorsList = new List<int>();

            while (input % 2 == 0) {
                primeFactorsList.Add(2);
                input /= 2;
            }

            for (int i = 3; i <= Math.Sqrt(input); i += 2) {
                while (input % i == 0) {
                    primeFactorsList.Add(i);
                    input /= i;
                }
            }

            if (input > 2) {
                primeFactorsList.Add(input);
            }

            return primeFactorsList;
        }
    }
}
