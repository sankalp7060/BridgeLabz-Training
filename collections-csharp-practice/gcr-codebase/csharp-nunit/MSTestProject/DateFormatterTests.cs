using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code;
using System;

namespace MSTestProject
{
    [TestClass]
    public class DateFormatterTests
    {
        private DateFormatter formatter;

        [TestInitialize]
        public void Setup() => formatter = new DateFormatter();

        [TestMethod]
        public void FormatDate_ValidDate_ShouldReturnCorrectFormat()
        {
            Assert.AreEqual("27-01-2026", formatter.FormatDate("2026-01-27"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FormatDate_InvalidDate_ShouldThrow() => formatter.FormatDate("invalid");
    }
}
