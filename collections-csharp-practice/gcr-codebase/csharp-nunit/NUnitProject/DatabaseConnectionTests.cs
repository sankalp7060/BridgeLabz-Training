using NUnit.Framework;
using Code;

namespace NUnitProject
{
    [TestFixture]
    public class DatabaseConnectionTests
    {
        private DatabaseConnection db;

        [SetUp]
        public void Setup() => db = new DatabaseConnection();

        [Test]
        public void Connect_ShouldSetIsConnectedTrue()
        {
            db.Connect();
            Assert.IsTrue(db.IsConnected);
        }

        [Test]
        public void Disconnect_ShouldSetIsConnectedFalse()
        {
            db.Connect();
            db.Disconnect();
            Assert.IsFalse(db.IsConnected);
        }
    }
}
