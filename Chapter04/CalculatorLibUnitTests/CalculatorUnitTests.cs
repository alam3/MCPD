using System;
using Xunit;
using UnitTesting;

namespace CalculatorLibUnitTests {
    public class CalculatorUnitTests {
        [Fact]
        public void TestAdding2And2() {
            // Arrange: declare and instantiate variables for input and output
            double a = 2;
            double b = 2;
            double expected = 4;
            var calc = new Calculator();

            // Act: execute the unit being tested, i.e. call the method being tested
            double actual = calc.Add(a, b);

            // Assert: verify that the test output matches the expected result
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAdding2And3() {
            double a = 2;
            double b = 3;
            double expected = 5;
            var calc = new Calculator();

            double actual = calc.Add(a, b);

            Assert.Equal(expected, actual);
        }
    }
}
