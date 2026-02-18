using TechVille.DSA.DataStructures.Queues;
using TechVille.DSA.Models;

namespace TechVille.DSA.Services
{
    // Queue-based service center
    public class ServiceQueueManager
    {
        ServiceQueue queue = new ServiceQueue();
        PriorityServiceQueue emergency = new PriorityServiceQueue();

        public void AddRequests()
        {
            queue.Enqueue(new ServiceRequest(1, "Water", 1));
            emergency.Add(new ServiceRequest(2, "Ambulance", 10));
        }

        public void Process()
        {
            var r = emergency.Process();
            if (r != null)
                System.Console.WriteLine("Emergency: " + r.ServiceName);

            var n = queue.Dequeue();
            if (n != null)
                System.Console.WriteLine("Normal: " + n.ServiceName);
        }
    }
}
