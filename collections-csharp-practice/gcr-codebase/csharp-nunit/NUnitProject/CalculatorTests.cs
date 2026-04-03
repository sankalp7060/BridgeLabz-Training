using NUnit.Framework; // Important! Must be NUnit
using Code;            // Your main project
using System;

namespace NUnitProject
{
    [TestFixture] // Instead of [TestClass]
    public class CalculatorTests
    {
        private Calculator calc;

        [SetUp] // Instead of [TestInitialize]
        public void Setup() => calc = new Calculator();

        [Test] // Instead of [TestMethod]
        public void Add_ShouldReturnSum()
        {
            Assert.AreEqual(5, calc.Add(2, 3));
        }

        [Test]
        public void Subtract_ShouldReturnDifference()
        {
            Assert.AreEqual(2, calc.Subtract(5, 3));
        }

        [Test]
        public void Multiply_ShouldReturnProduct()
        {
            Assert.AreEqual(6, calc.Multiply(2, 3));
        }

        [Test]
        public void Divide_ShouldReturnQuotient()
        {
            Assert.AreEqual(2, calc.Divide(6, 3));
        }

        [Test]
        public void Divide_ByZero_ShouldThrowException()
        {
            Assert.Throws<DivideByZeroException>(() => calc.Divide(5, 0));
        }
    }
}
