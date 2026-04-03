using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code;
using System;

namespace MSTestProject
{
    [TestClass]
    public class ExceptionHandlerTests
    {
        private ExceptionHandler handler;

        [TestInitialize]
        public void Setup() => handler = new ExceptionHandler();

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Divide_ByZero_ShouldThrow() => handler.Divide(5, 0);

        [TestMethod]
        public void Divide_ShouldReturnQuotient() => Assert.AreEqual(2, handler.Divide(6, 3));
    }
}
