using NUnit.Framework;
using Code;
using System.Collections.Generic;

namespace NUnitProject
{
    [TestFixture]
    public class ListManagerTests
    {
        private ListManager manager;
        private List<int> list;

        [SetUp]
        public void Setup()
        {
            manager = new ListManager();
            list = new List<int>();
        }

        [Test]
        public void AddElement_ShouldAdd()
        {
            manager.AddElement(list, 5);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void RemoveElement_ShouldRemove()
        {
            list.Add(10);
            manager.RemoveElement(list, 10);
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void GetSize_ShouldReturnCount()
        {
            list.Add(1);
            list.Add(2);
            Assert.AreEqual(2, manager.GetSize(list));
        }
    }
}
