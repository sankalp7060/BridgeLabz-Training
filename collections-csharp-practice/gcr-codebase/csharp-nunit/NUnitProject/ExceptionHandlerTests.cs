using NUnit.Framework;
using Code;
using System;

namespace NUnitProject
{
    [TestFixture]
    public class ExceptionHandlerTests
    {
        private ExceptionHandler handler;

        [SetUp]
        public void Setup() => handler = new ExceptionHandler();

        [Test]
        public void Divide_ShouldReturnQuotient() => Assert.AreEqual(2, handler.Divide(6, 3));

        [Test]
        public void Divide_ByZero_ShouldThrow() => Assert.Throws<ArithmeticException>(() => handler.Divide(5, 0));
    }
}
