using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code;

namespace MSTestProject
{
    [TestClass]
    public class PerformanceTasksTests
    {
        private PerformanceTasks task;

        [TestInitialize]
        public void Setup() => task = new PerformanceTasks();

        [TestMethod]
        [Timeout(2000)]
        public void LongRunningTask_ShouldTimeout()
        {
            task.LongRunningTask();
        }
    }
}
