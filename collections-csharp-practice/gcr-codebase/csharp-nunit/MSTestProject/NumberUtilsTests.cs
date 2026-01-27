using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code;

namespace MSTestProject
{
    [TestClass]
    public class NumberUtilsTests
    {
        private NumberUtils utils;

        [TestInitialize]
        public void Setup() => utils = new NumberUtils();

        [TestMethod]
        [DataRow(2, true)]
        [DataRow(4, true)]
        [DataRow(6, true)]
        [DataRow(7, false)]
        [DataRow(9, false)]
        public void IsEven_ShouldReturnCorrectValue(int num, bool expected)
        {
            Assert.AreEqual(expected, utils.IsEven(num));
        }
    }
}
