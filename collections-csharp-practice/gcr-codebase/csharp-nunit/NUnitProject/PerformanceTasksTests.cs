using NUnit.Framework;
using Code;
using System.Threading;

namespace NUnitProject
{
    [TestFixture]
    public class PerformanceTasksTests
    {
        private PerformanceTasks task;

        [SetUp]
        public void Setup() => task = new PerformanceTasks();

        [Test, Timeout(2000)]
        public void LongRunningTask_ShouldTimeout()
        {
            task.LongRunningTask();
        }
    }
}
