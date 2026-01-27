using NUnit.Framework;
using Code;
using System;

namespace NUnitProject
{
    [TestFixture]
    public class DateFormatterTests
    {
        private DateFormatter formatter;

        [SetUp]
        public void Setup() => formatter = new DateFormatter();

        [Test]
        public void FormatDate_ValidDate_ShouldReturnCorrectFormat()
        {
            Assert.AreEqual("27-01-2026", formatter.FormatDate("2026-01-27"));
        }

        [Test]
        public void FormatDate_InvalidDate_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => formatter.FormatDate("invalid"));
        }
    }
}
