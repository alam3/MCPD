using System;
using Xunit;
using PrimeFactorsLib;
using System.Collections.Generic;

namespace PrimeFactorsLibUnitTests {
    public class PrimeFactorsUnitTests {
        [Fact]
        public void TestingPF4() {
            // Arrange
            int input = 4;
            List<int> expected = new List<int>();
            expected.Add(2);
            expected.Add(2);
            // Act
            var pfCalc = new PrimeFactors();
            List<int> actual = pfCalc.PrimeFactorsCalc(input);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestingPF7() {
            int input = 7;
            List<int> expected = new List<int>();
            expected.Add(7);

            var pfCalc = new PrimeFactors();
            List<int> actual = pfCalc.PrimeFactorsCalc(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestingPF30() {
            int input = 30;
            List<int> expected = new List<int>();
            expected.Add(2);
            expected.Add(3);
            expected.Add(5);

            var pfCalc = new PrimeFactors();
            List<int> actual = pfCalc.PrimeFactorsCalc(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestingPF40() {
            int input = 40;
            List<int> expected = new List<int>();
            expected.Add(2);
            expected.Add(2);
            expected.Add(2);
            expected.Add(5);

            var pfCalc = new PrimeFactors();
            List<int> actual = pfCalc.PrimeFactorsCalc(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestingPF50() {
            int input = 50;
            List<int> expected = new List<int>();
            expected.Add(2);
            expected.Add(5);
            expected.Add(5);

            var pfCalc = new PrimeFactors();
            List<int> actual = pfCalc.PrimeFactorsCalc(input);

            Assert.Equal(expected, actual);
        }
    }
}
