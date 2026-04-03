using System.Threading;

namespace Code;

public class PerformanceTasks
{
	public string LongRunningTask()
	{
		Thread.Sleep(3000); // Simulate long task
		return "Done";
	}
}
