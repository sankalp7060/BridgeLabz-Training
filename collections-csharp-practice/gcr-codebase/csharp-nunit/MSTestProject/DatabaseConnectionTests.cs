using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code;

namespace MSTestProject
{
    [TestClass]
    public class DatabaseConnectionTests
    {
        private DatabaseConnection db;

        [TestInitialize]
        public void Setup() => db = new DatabaseConnection();

        [TestMethod]
        public void Connect_ShouldSetIsConnectedTrue()
        {
            db.Connect();
            Assert.IsTrue(db.IsConnected);
        }

        [TestMethod]
        public void Disconnect_ShouldSetIsConnectedFalse()
        {
            db.Connect();
            db.Disconnect();
            Assert.IsFalse(db.IsConnected);
        }
    }
}
