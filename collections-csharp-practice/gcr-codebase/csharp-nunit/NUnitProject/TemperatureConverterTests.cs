using NUnit.Framework;
using Code;

namespace NUnitProject
{
    [TestFixture]
    public class TemperatureConverterTests
    {
        private TemperatureConverter converter;

        [SetUp]
        public void Setup() => converter = new TemperatureConverter();

        [Test]
        public void CelsiusToFahrenheit_ShouldReturnCorrectValue() => Assert.AreEqual(212, converter.CelsiusToFahrenheit(100));

        [Test]
        public void FahrenheitToCelsius_ShouldReturnCorrectValue() => Assert.AreEqual(100, converter.FahrenheitToCelsius(212));
    }
}
