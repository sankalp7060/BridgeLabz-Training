using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code;
using System;

namespace MSTestProject
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator calc;

        [TestInitialize]
        public void Setup() => calc = new Calculator();

        [TestMethod]
        public void Add_ShouldReturnSum() => Assert.AreEqual(5, calc.Add(2, 3));

        [TestMethod]
        public void Subtract_ShouldReturnDifference() => Assert.AreEqual(2, calc.Subtract(5, 3));

        [TestMethod]
        public void Multiply_ShouldReturnProduct() => Assert.AreEqual(6, calc.Multiply(2, 3));

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_ByZero_ShouldThrowException() => calc.Divide(5, 0);

        [TestMethod]
        public void Divide_ShouldReturnQuotient() => Assert.AreEqual(2, calc.Divide(6, 3));
    }
}
