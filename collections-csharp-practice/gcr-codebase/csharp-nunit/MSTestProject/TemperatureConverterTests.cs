using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code;

namespace MSTestProject
{
    [TestClass]
    public class TemperatureConverterTests
    {
        private TemperatureConverter converter;

        [TestInitialize]
        public void Setup() => converter = new TemperatureConverter();

        [TestMethod]
        public void CelsiusToFahrenheit_ShouldReturnCorrectValue() => Assert.AreEqual(212, converter.CelsiusToFahrenheit(100));

        [TestMethod]
        public void FahrenheitToCelsius_ShouldReturnCorrectValue() => Assert.AreEqual(100, converter.FahrenheitToCelsius(212));
    }
}
